using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace RussianHills
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    class InventoryDAL
    {
        /*        public void InsertData(int id, string name, string city, DateTime date)
                {
                    string sql = string.Format("INSERT INTO [Table]" +
                       "([Id], [Name], [City],[Date]) Values(@Id,@Name,@City,@Date)");

                    using (SqlConnection con = new SqlConnection(
                   ConsoleApp1.Properties.Settings.Default.Database1ConnectionString))
                    {

                        try
                        {
                            con.Open();
                            using (SqlCommand cmd = new SqlCommand(sql, con))
                            {
                                SqlParameter param = new SqlParameter();
                                param.ParameterName = "@Id";
                                param.Value = id;
                                param.SqlDbType = SqlDbType.Int;
                                cmd.Parameters.Add(param);

                                param = new SqlParameter();
                                param.ParameterName = "@Name";
                                param.Value = name;
                                param.SqlDbType = SqlDbType.VarChar;
                                param.Size = 20;
                                cmd.Parameters.Add(param);

                                param = new SqlParameter();
                                param.ParameterName = "@City";
                                param.Value = city;
                                param.SqlDbType = SqlDbType.Char;
                                param.Size = 10;
                                cmd.Parameters.Add(param);

                                param = new SqlParameter();
                                param.ParameterName = "@Date";
                                param.Value = date;
                                param.SqlDbType = SqlDbType.Date;
                                param.Size = 10;
                                cmd.Parameters.Add(param);

                                cmd.ExecuteNonQuery();
                            }
                        }
                        catch (SqlException ex)
                        { Console.WriteLine(ex.Message); }
                        finally
                          { con.Close(); }
                    }
                } */
        public void DeleteData(int id)
        {
            string sql = string.Format("DELETE FROM [Table] WHERE [Id] = '{0}'", id);

            using (SqlConnection con = new SqlConnection(
          RussianHills.Properties.Settings.Default.Database1ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {

                    }
                    finally
                    {
                        con.Close();
                    }
                }

            }
        }

        public void ChangeData(int id, string newName)
        {
            string sql = string.Format("UPDATE [Table] SET [Name] = '{0}' WHERE [Id] = '{1}'",
               newName, id);
            using (SqlConnection con = new SqlConnection(
              RussianHills.Properties.Settings.Default.Database1ConnectionString))
            {
                try
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                { }
                finally
                { con.Close(); }
            }
        }

        public DataTable GetAllYableAsDataTable(string tablee)
        {
            DataTable table = new DataTable();
            string sql = String.Format("SELECT * FROM [{0}]", tablee);
            using (SqlConnection con = new SqlConnection(
              RussianHills.Properties.Settings.Default.Database1ConnectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        table.Load(dr);
                        dr.Close();
                    }
                }
                catch (SqlException ex)
                { }
                finally
                { con.Close(); }

                return table;
            }
        }

        public void InsertCrew(int num, string drivers, string city, string car, string group, string carClass, string tableName)
        {
            string sql = string.Format("INSERT INTO [{0}]" +
               "([Num],[Drivers],[City],[Car],[Group],[CarClass]) Values(@Num,@Drivers,@City,@Car,@Group,@CarClass)", tableName);

            using (SqlConnection con = new SqlConnection(
           RussianHills.Properties.Settings.Default.Database1ConnectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        SqlParameter param = new SqlParameter();
                        param.ParameterName = "@Num";
                        param.Value = num;
                        param.SqlDbType = SqlDbType.Int;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@Drivers";
                        param.Value = drivers;
                        param.SqlDbType = SqlDbType.VarChar;
                        param.Size = 50;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@City";
                        param.Value = city;
                        param.SqlDbType = SqlDbType.VarChar;
                        param.Size = 50;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@Car";
                        param.Value = car;
                        param.SqlDbType = SqlDbType.VarChar;
                        param.Size = 50;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@Group";
                        param.Value = group;
                        param.SqlDbType = SqlDbType.VarChar;
                        param.Size = 50;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@CarClass";
                        param.Value = carClass;
                        param.SqlDbType = SqlDbType.VarChar;
                        param.Size = 50;
                        cmd.Parameters.Add(param);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                { Console.WriteLine(ex.Message); }
                finally
                { con.Close(); }
            }
        }

        public void InsertRace(int id, string title, DateTime dateBegin, DateTime dateEnd, double pointRate, int countST, int penaltyToLate, int penaltyToHold, int penaltyKP, int penaltyKS, string tableName)
        {
            string sql = string.Format("INSERT INTO [{0}]" +
               "([Id],[Title],[DateBegin],[DateEnd],[PointRate],[CountST],[PenaltyToLate],[PenaltyToHold],[PenaltyKP],[PenaltyKS]) Values(@Id,@Title,@DateBegin,@DateEnd,@PointRate,@CountST,@PenaltyToLate,@PenaltyToHold,@PEnaltyKP,@PenaltyKS)", tableName);

            using (SqlConnection con = new SqlConnection(
           RussianHills.Properties.Settings.Default.Database1ConnectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        SqlParameter param = new SqlParameter();
                        param.ParameterName = "@Id";
                        param.Value = id;
                        param.SqlDbType = SqlDbType.Int;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@Title";
                        param.Value = title;
                        param.SqlDbType = SqlDbType.VarChar;
                        param.Size = 50;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@DateBegin";
                        param.Value = dateBegin;
                        param.SqlDbType = SqlDbType.Date;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@DateEnd";
                        param.Value = dateEnd;
                        param.SqlDbType = SqlDbType.Date;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@PointRate";
                        param.Value = pointRate;
                        param.SqlDbType = SqlDbType.Float;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@CountST";
                        param.Value = countST;
                        param.SqlDbType = SqlDbType.Int;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@PenaltyToLate";
                        param.Value = penaltyToLate;
                        param.SqlDbType = SqlDbType.Int;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@PenaltyToHold";
                        param.Value = penaltyToHold;
                        param.SqlDbType = SqlDbType.Int;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@PenaltyKP";
                        param.Value = penaltyKP;
                        param.SqlDbType = SqlDbType.Int;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@PenaltyKS";
                        param.Value = penaltyKS;
                        param.SqlDbType = SqlDbType.Int;
                        cmd.Parameters.Add(param);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                { Console.WriteLine(ex.Message); }
                finally
                { con.Close(); }
            }
        }

    }

    /*  struct Crew
{
	int    num;	// стартовый номер
	string drivers; // водители
	string city;	// город
	string car;	// авто
	string group;	// зачетная группа
	string class;	// класс
}

struct Cource
{
	int 	 num;			// стартовый номер экипажа
	int 	 countKPpass;		// количество пройденных КП
	DateTime penaltyTimeKP;		// штрафное время за непройденные КП
	int 	 countKSpass;		// количество пройденных КС
	DateTime penaltyTimeKS;		// штрафное время за непройденные КС
	DateTime arrivePlan;		// время прибытия на старт плановое
	DateTime arriveFact;		// время прибытия на старт фактическое
	DateTime penaltyTimeToLate; 	// штрафное время за опоздание на старт
	DateTime startPlan;		// время старта плановое
	DateTime startFact;		// время старта фактическое
	DateTime penaltyTimeToHold;	// штрафное время за задержку старта
	DateTime timeFinish;		// время финиша
	DateTime timeToPass;		// время, потраченное на спецучасток
	DateTime penaltyTimeAll;	// сумма штрафов
	DateTime timeFinally;		// итоговое время с учетом штрафов
}

struct Track
{
	int 	 Id;			// номер СУ
	int	 CountKP;		// количество КП
	int	 CountKS;		// количество КС
	double 	 PointRate;		// коэффициент очков
	DateTime Period			// промежуток между участниками
}

struct Race
{
	int 	 id;		// идентификатор гонки
	string 	 title;		// наименование гонки
	DateTime dateBegin;	// дата начала
	DateTime dateEnd;	// дата конца
	int 	 countST;	// количество спец участков
	int 	 penaltyToLate;	// штраф за опоздание
	int 	 penaltyToHold;	// штраф за задержку старта
	int 	 penaltyKP;	// штраф за пропуск КП
	int 	 penaltyKS;	// штраф за пропуск КС
}
       */
}
