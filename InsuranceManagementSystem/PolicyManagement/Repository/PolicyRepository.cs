using PolicyManagement.Constants;
using PolicyManagement.Model;
using PolicyManagement.Exceptions;
using System.Data.SqlClient;
using PolicyManagement.Utility;
using System.Data;

namespace PolicyManagement.Repository
{
    internal class PolicyRepository : IPolicyRepository
    {
        SqlConnection sqlConnection;
        SqlCommand cmd = null;
        string connString;
        List<Policy> policyList;


        private int nextid = 0;
        public PolicyRepository()
        {
            connString = DbConnUtil.GetConnectionString();
            cmd= new SqlCommand();

        }
       
        public int AddPolicy(Policy policy)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                cmd.CommandText = "Insert into Policies (PolicyHolderName,PolicyType,StartDate,EndDate) values(@PolicyHolderName,@PolicyType,@StartDate,@EndDate)";
                cmd.Parameters.AddWithValue("@PolicyHolderName", policy.PolicyHolderName);
                cmd.Parameters.AddWithValue("@PolicyType", policy.PolicyType);
                cmd.Parameters.AddWithValue("@StartDate", policy.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", policy.EndDate);
                cmd.Connection=sqlConnection;
                sqlConnection.Open();
                return cmd.ExecuteNonQuery();

            }
           
        }
        public Policy SearchPolicyById(int id)
        {
            List<Policy> policylist = ViewAllPolicies();
            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                try
                {
                    if (!policylist.Any(p => p.PolicyId == id))
                    {
                        throw new PolicyNotFoundException($"Policy No {id} not Found");
                    }
                    Console.WriteLine("Details Of searched Policy:");
                    cmd.Parameters.Clear();
                    cmd.CommandText = "select * from Policies where PolicyId=@PolicyId";
                    cmd.Parameters.AddWithValue("@PolicyId", id);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Policy policy = new Policy();
                        policy.PolicyId = (int)reader["PolicyId"];
                        policy.PolicyHolderName = (string)reader["PolicyHolderName"];
                        policy.PolicyType = (PolicyType)reader["PolicyType"];
                        policy.StartDate = (DateTime)reader["StartDate"];
                        policy.EndDate = (DateTime)reader["EndDate"];
                        return policy;
                    }
                }
                catch (PolicyNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
                return null;
            }
        }
        public int UpdatePolicyDetails(int id)
        {
            List<Policy> policylist = ViewAllPolicies();
            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {

                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                try
                {
                    if (!policylist.Any(p =>p.PolicyId==id))
                    {
                        throw new PolicyNotFoundException($"Policy No {id} Not Found");
                    }
                    while (true)
                    {
                        Console.WriteLine("choose the Option");
                        Console.WriteLine("1.Update name\n2.Update Policy Type\n3.Update Start Date\n4.Update End Date\n5.Exit");
                        Console.WriteLine("Enter Your Choice");
                        int option = Convert.ToInt32(Console.ReadLine());
                        switch (option)
                        {
                            case 1:
                                Console.WriteLine("Enter Policy Holder name");
                                string name = Console.ReadLine();
                                cmd.Parameters.Clear();
                                cmd.CommandText = "Update Policies Set PolicyHolderName=@PolicyHolderName WHERE PolicyId=@PolicyId";
                                cmd.Parameters.AddWithValue("@PolicyHolderName", name);
                                cmd.Parameters.AddWithValue("@PolicyId", id);
                                Console.WriteLine("Name Updated Successfuly");
                                cmd.ExecuteNonQuery();
                                break;
                            case 2:
                                Console.Write("Enter Policy Type (Life, Health, Vehicle, Property): ");
                                PolicyType type = (PolicyType)Enum.Parse(typeof(PolicyType), Console.ReadLine(), true);
                                cmd.Parameters.Clear();
                                cmd.CommandText = "Update Policies Set PolicyType=@PolicyType WHERE PolicyId=@PolicyId";
                                cmd.Parameters.AddWithValue("@PolicyType", type);
                                cmd.Parameters.AddWithValue("@PolicyId", id);
                                Console.WriteLine("Policy Type Updated Successfuly");
                                cmd.ExecuteNonQuery();
                                break;
                            case 3:
                                Console.Write("Enter Start Date (yyyy-MM-dd): ");
                                DateTime StartDate = DateTime.Parse(Console.ReadLine());
                                cmd.Parameters.Clear();
                                cmd.CommandText = "Update Policies Set StartDate=@StartDate WHERE PolicyId=@PolicyId";
                                cmd.Parameters.AddWithValue("@StartDate", StartDate);
                                cmd.Parameters.AddWithValue("@PolicyId", id);
                                Console.WriteLine("Start Date Updated successFuly");
                                cmd.ExecuteNonQuery();
                                break;
                            case 4:
                                Console.Write("Enter End Date (yyyy-MM-dd): ");
                                DateTime EndDate = DateTime.Parse(Console.ReadLine());
                                cmd.Parameters.Clear();
                                cmd.CommandText = "Update Policies Set EndDate=@EndDate WHERE PolicyId=@PolicyId";
                                cmd.Parameters.AddWithValue("@EndDate", EndDate);
                                cmd.Parameters.AddWithValue("@PolicyId", id);
                                Console.WriteLine("End Date Updated successFuly");
                                cmd.ExecuteNonQuery();
                                break;
                            case 5:
                                return cmd.ExecuteNonQuery();
                            default:
                                Console.WriteLine("please enter valid option(1-4)");
                                break;
                        }
                    }
                }
                catch (PolicyNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }
        public int DeletePolicy(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {  
                try
                {
                    if (!policyList.Any(p => p.PolicyId == id))
                    {
                        throw new PolicyNotFoundException($"Policy {id} not Found");
                    }
                    cmd.Parameters.Clear();
                    cmd.CommandText = "DELETE FROM Policies WHERE PolicyId=@PolicyId";
                    cmd.Parameters.AddWithValue("@PolicyId", id);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    return cmd.ExecuteNonQuery();
                }
                catch (PolicyNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
            
        }
        public bool IsActive(Policy policy)
        {
            DateTime currentdate = DateTime.Now;
            if (currentdate.Date >= policy.StartDate.Date && currentdate.Date <= policy.EndDate.Date)
            {
                return true;
            }
            return false;
        }

        public List<Policy> ViewActivePolicies()
        {
            List<Policy> policylist = new List<Policy>();
            DateTime currentdate = DateTime.Now;
            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "select * from Policies where @CurrentDate between StartDate and EndDate";
                cmd.Parameters.AddWithValue("@CurrentDate", currentdate.Date);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Policy policy = new Policy();
                    policy.PolicyId = reader.GetInt32("PolicyId");
                    policy.PolicyHolderName = (string)reader["PolicyHolderName"];
                    policy.PolicyType = (PolicyType)reader["PolicyType"];
                    policy.StartDate = (DateTime)reader["StartDate"];
                    policy.EndDate = (DateTime)reader["EndDate"];
                    policylist.Add(policy);
                }
                return policylist;
            }
        }
        public List<Policy> ViewAllPolicies()
        {
            policyList=new List<Policy>();
            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {

                cmd.CommandText = "select * from Policies";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Policy policy = new Policy();
                    policy.PolicyId = reader.GetInt32("PolicyId");
                    policy.PolicyHolderName = (string)reader["PolicyHolderName"];
                    policy.PolicyType = (PolicyType) reader["PolicyType"];
                    policy.StartDate = (DateTime)reader["StartDate"];
                    policy.EndDate = (DateTime)reader["EndDate"];
                    policyList.Add(policy);
                }
                return policyList;
            }
        }
    }
}
