using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using taskEnd.BusinessRule;



namespace taskEnd.DataAcess
{




    class DBConnection
    {
        private MySqlConnection connection;
        private string connectionStr;


        
        string alltable = "u_date,u_expend,u_add_date,u_add_class,u_add_note from u_consum_daily";
        //数据库的调用
        public DBConnection()
        {

        }
        public DBConnection(string connectionString)
        {
            try
            {
                string connectionStr = connectionString; 
                connection = new MySqlConnection(connectionStr);
            }
            catch (Exception exception)
            {
                throw new Exception("DBConnection Constructor:" + exception.Message);
            }
        }


        //数据集的增删该查





        //————————————————————获取用户昵称
        public string get_Nickname(string user_id,string strConnection)
        {
            string end;
            string jiayou = "加油！";
            try
            {
                MySqlConnection objConnection = new MySqlConnection(strConnection);
                objConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("select * from user_account where u_id='" + user_id + "'", objConnection);//select * from 表名
                MySqlDataReader dataReader = mySqlCommand.ExecuteReader();
                if (dataReader.Read())
                {
                    end = dataReader[3].ToString();
                    return end;
                }
                else
                {
                    MessageBox.Show("加油！！！");
                }
                //return end;
                return jiayou;

            }
            catch (Exception exception)
            {
                throw new Exception("SelectMethod:" + exception.Message);
            }
            finally
            {
                connection.Close();
            }
        }









        //————————————————————在datagridview控件中显示数据字段
        public DataSet Selected_table_Toshow(string selected_table,string user_id)
        {
            try
            {
                if (connection != null)
                {
                    connection.Open();
                }


                string cmdStr = "Select u_date,u_expend from " + selected_table + " where u_id = " + user_id;
                MySqlCommand sqlCmd = new MySqlCommand(cmdStr, connection);
                MySqlDataAdapter sda = new MySqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds, selected_table);
                return ds;
            }
            
            catch (Exception exception)
            {
                throw new Exception("SelectMethod:" + exception.Message);
            }
            finally
            {
                connection.Close();
            }

        }
        public DataSet Show_all_record(string selected_table, string user_id)
        {
            try
            {
                if (connection != null)
                {
                    connection.Open();
                }


                string table_daily = "Select u_date,u_expend,u_add_date,u_add_class,u_add_note from u_consum_daily where u_id = " + user_id;
                string table_amuse = "Select u_date,u_expend,u_add_date,u_add_class,u_add_note from u_consum_amuse where u_id = " + user_id;
                string table_clo = "Select u_date,u_expend,u_add_date,u_add_class,u_add_note from u_consum_clo where u_id = " + user_id;
                string table_edu = "Select u_date,u_expend,u_add_date,u_add_class,u_add_note from u_consum_edu where u_id = " + user_id;
                string table_teansfer = "Select u_date,u_expend,u_add_date,u_add_class,u_add_note from u_consum_transfer where u_id = " + user_id;
                string table_other = "Select u_date,u_expend,u_add_date,u_add_class,u_add_note from u_consum_other where u_id = " + user_id;
                string Linker = " union ";
                string cmdStr = table_daily + Linker + table_amuse + Linker + table_clo + Linker + table_edu + Linker + table_teansfer + Linker + table_other;
                MySqlCommand sqlCmd = new MySqlCommand(cmdStr, connection);
                MySqlDataAdapter sda = new MySqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds, selected_table);
                return ds;
            }

            catch (Exception exception)
            {
                throw new Exception("SelectMethod:" + exception.Message);
            }
            finally
            {
                connection.Close();
            }

        }


        public DataSet Filter(string table, string date, string amount,string user_id)
        {
            
            try
            {
               
                DataSet ds = new DataSet();
                
                if (connection != null)
                {
                    connection.Open();
                }
                if (table != "" & date=="" & amount== "")
                {
                    
                    string cmdStr = "select*from " + table + " where u_id =" + user_id ;
                    MySqlCommand sqlCmd = new MySqlCommand(cmdStr, connection);
                    MySqlDataAdapter sda = new MySqlDataAdapter(sqlCmd);
                    sda.Fill(ds, table);
                   
                }
                else if(table != "" & date != "" & amount== "")
                {
                    string cmdStr = "select * from " + alltable + " where u_id = "+user_id+" and u_date = "+date;
                    MySqlCommand sqlCmd = new MySqlCommand(cmdStr, connection);
                    MySqlDataAdapter sda = new MySqlDataAdapter(sqlCmd);
                    sda.Fill(ds, table);
                }
                else if(table != "" & amount != "" & date== "")
                {
                    string cmdStr = "select * from " + table + " where u_id = " + user_id + " and u_expend = " + amount;
                    MySqlCommand sqlCmd = new MySqlCommand(cmdStr, connection);
                    MySqlDataAdapter sda = new MySqlDataAdapter(sqlCmd);
                    sda.Fill(ds, table);
                }
                else if(table != "" & date != "" & amount != "")
                {
                    string cmdStr = "select * from " + table + " where u_id = " + user_id + " and u_date = '" + date +"' and u_expend = " + amount;
                    MySqlCommand sqlCmd = new MySqlCommand(cmdStr, connection);
                    MySqlDataAdapter sda = new MySqlDataAdapter(sqlCmd);
                    sda.Fill(ds, table);
                }
                else
                {
                    MessageBox.Show("Please add filter!^v^");
                };
                return ds;
            }
            catch (Exception exception)
            {
                throw new Exception("FilterMethod:" + exception.Message);
            }
            finally
            {
                connection.Close();
            }
        }


        public DataSet Delete( string type,string expend)
        {
            Judge judeg = new Judge();
            string table = judeg.judge_table(type);
            //用eunm进行优化
            try
            {
                if (connection != null)
                {
                    connection.Open();
                }
                
                string cmdStr = "delete from "+table+" where u_expend = " + expend ;
                MySqlCommand sqlCmd = new MySqlCommand(cmdStr, connection);
                MySqlDataAdapter sda = new MySqlDataAdapter(sqlCmd);

                DataSet ds = new DataSet();
                sda.Fill(ds, "userInformation");
                return ds;
            }
            catch (Exception exception)
            {
                
                throw new Exception("DeleteMethod:" + exception.Message);
            }
            finally
            {
                connection.Close();
            }

        }
        public DataSet Show_in_chat(string user_id)
        {

            string test_table = "u_consum_daily";
            try
            {
                if (connection != null)
                {
                    connection.Open();
                }


                string table_daily = "Select u_date,u_expend,u_add_date,u_add_class,u_add_note from u_consum_daily where u_id = " + user_id;
                string table_amuse = "Select u_date,u_expend,u_add_date,u_add_class,u_add_note from u_consum_amuse where u_id = " + user_id;
                string table_clo = "Select u_date,u_expend,u_add_date,u_add_class,u_add_note from u_consum_clo where u_id = " + user_id;
                string table_edu = "Select u_date,u_expend,u_add_date,u_add_class,u_add_note from u_consum_edu where u_id = " + user_id;
                string table_teansfer = "Select u_date,u_expend,u_add_date,u_add_class,u_add_note from u_consum_transfer where u_id = " + user_id;
                string table_other = "Select u_date,u_expend,u_add_date,u_add_class,u_add_note from u_consum_other where u_id = " + user_id;
                string Linker = " union ";
                string cmdStr = table_daily + Linker + table_amuse + Linker + table_clo + Linker + table_edu + Linker + table_teansfer + Linker + table_other;
                MySqlCommand sqlCmd = new MySqlCommand(cmdStr, connection);
                MySqlDataAdapter sda = new MySqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds, test_table);

                return ds;
            }

            catch (Exception exception)
            {
                throw new Exception("SelectMethod:" + exception.Message);
            }
            finally
            {
                connection.Close();
            }

        }
        public DataSet Alter_account(string user_id,string new_password)
        {

            string alter_table = "user_account";
            
            try
            {
                if (connection != null)
                {
                    connection.Open();
                }



                string cmdStr = "UPDATE "+ alter_table + " SET u_password = '"+new_password+"'WHERE u_id = '"+user_id+"'";
                MySqlCommand sqlCmd = new MySqlCommand(cmdStr, connection);
                MySqlDataAdapter sda = new MySqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds, alter_table);

                return ds;
            }

            catch (Exception exception)
            {
                throw new Exception("SelectMethod:" + exception.Message);
            }
            finally
            {
                connection.Close();
            }

        }
        public DataSet Alter_data(string user_id, string flag , string new_expend , string new_note ,string new_type , string new_add_date)
        {
                try
            {
                if (connection != null)
                {
                    connection.Open();
                }

                string cmdStr = "UPDATE " + flag + " SET u_expend = " + new_expend + ",u_add_note = '" + new_note + "',u_add_class = '" + new_type + "',u_add_date = '" + new_add_date + "' WHERE u_id = " + user_id;
                MySqlCommand sqlCmd = new MySqlCommand(cmdStr, connection);
                MySqlDataAdapter sda = new MySqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds, flag);

                return ds;
            }

            catch (Exception exception)
            {
                throw new Exception("SelectMethod:" + exception.Message);
            }
            finally
            {
                connection.Close();
            }

        }
    }
}
