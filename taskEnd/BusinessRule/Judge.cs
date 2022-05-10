using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskEnd.BusinessRule
{
    class Judge
    {
        public Judge()
        {

        }
        public string judge_table(string type)
        {
            string table = "";

            if (type == "amuse")
            {
                table = "u_consum_amuse";
            }
            else if (type == "clothes")
            {
                table = "u_consum_clo";
            }
            else if (type == "daily")
            {
                table = "u_consum_daily";
            }
            else if (type == "education")
            {
                table = "u_consum_edu";
            }
            else if (type == "other")
            {
                table = "u_consum_other";
            }
            else if (type == "transfer")
            {
                table = "u_consum_transfer";
            }
            return table;
        }

        public string judge_type(string type)
        {
            string table = "";

            if (type == "amuse")
            {
                table = "u_consum_amuse";
            }
            else if (type == "clo")
            {
                table = "u_consum_clo";
            }
            else if (type == "daily")
            {
                table = "u_consum_daily";
            }
            else if (type == "edu")
            {
                table = "u_consum_edu";
            }
            else if (type == "other")
            {
                table = "u_consum_other";
            }
            else if (type == "transfer")
            {
                table = "u_consum_transfer";
            }
            else
            {
                table = "1";
            }
            return table;
        }

    }
}
