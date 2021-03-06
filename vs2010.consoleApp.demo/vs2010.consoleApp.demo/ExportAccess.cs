﻿using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using ADOX;
using System.IO;
using System.Data;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace vs2010.consoleApp.demo
{

    class ExportAccess
    {
        private static String Table_name = "export.mdb";
        static String JetProvider = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};";
        static Dictionary<String, ISet<String>> typeFields = new Dictionary<string, ISet<string>>();
        static Dictionary<String, ISet<String>> typeSqlParams = new Dictionary<string, ISet<String>>();
        static Dictionary<String, String> typeInsertSql = new Dictionary<string, string>();
        static Dictionary<String, String> typeSelectSql = new Dictionary<string, string>();
        private static bool flag = false;
        //static int threshold = 100000;
        private static void InitFields()
        {
            if (!flag)
            {

                ISet<string> mediaObject = new HashSet<string>();
                mediaObject.UnionWith("_id,media".Split(','));
                ISet<String> qkFields = new HashSet<String>();
                qkFields.UnionWith(
                    "lngid,titletype,mediaid,media_c,media_e,years,vol,num,volumn,specialnum,subjectnum,gch,title_c,title_e,keyword_c,keyword_e,remark_c,remark_e,class,beginpage,endpage,jumppage,pagecount,showwriter,showorgan,imburse,author_e,medias_qk,refercount,referids,intpdf,isqwkz,intgby,isinclude,range,fstorgan,fstwriter,muinfo,language,issn,type"
                        .Split(','));
                //typeFields.Add("1", qkFields);
                typeFields.Add("media", mediaObject);
                flag = true;
            }
        }

        public static void Export(String dataPath,int startFileNum)
        {
            InitFields();
            String key = "media";
            int fileCounts = startFileNum;
            //mdb
            String connectionString = String.Format(JetProvider, fileCounts + "_" + Table_name);
            InitMdb(connectionString);
            OleDbConnection conn = new OleDbConnection(connectionString);
            conn.Open();
            //read file
            StreamReader reader = new StreamReader(new BufferedStream(new FileStream(dataPath, FileMode.Open)));
            String line = reader.ReadLine();
            int counts = 1;
            while (line != null)
            {
                JObject obj = JObject.Parse(line);
                ACEParameterHelper parameterHelper = new ACEParameterHelper();
                //String type = obj["type"].ToString();
                int i = 0;

                foreach (var type in typeFields)
                {
                    foreach (var field in type.Value)
                    {
                        parameterHelper.AddParameter<String>(field, obj[field].ToString());
                         i++;
                    }

                }
                AccessHelper.ExecuteNonQuery(conn, typeInsertSql[key], parameterHelper.GetParameters());
                //if (counts >= threshold)
                //{

                //    fileCounts++;
                //    conn.Close();
                //    connectionString = String.Format(JetProvider, fileCounts + "_" + Table_name);
                //    InitMdb(connectionString);
                //    conn = new OleDbConnection(connectionString);
                //    conn.Open();
                //    counts = 0;
                //}
                counts++;
                line = reader.ReadLine();
            }
            reader.Close();
            if (conn != null)
                conn.Close();
        }
    
        public static void InitMdb(String connectionString)
        {
            CreateMdb(connectionString);
            CreateTable(connectionString);

        }
        public static void CreateMdb(String connectionString)
        {


            ADOX.CatalogClass cat = new ADOX.CatalogClass();
            cat.Create(connectionString);
            cat = null;


        }
        public static void CreateTable(String connectionString)
        {
            foreach (KeyValuePair<string, ISet<string>> pair in typeFields)
            {
                StringBuilder builder = new StringBuilder(100);
                StringBuilder insertSqlBuilder = new StringBuilder(100);
                StringBuilder selectSqlBuilder = new StringBuilder(100);
                String selectSql = "select {0} from table_" + pair.Key;
                String insertSql = "insert into table_" + pair.Key + "({0}) values ({1})";
                ISet<String> paramsFields = new HashSet<string>();
                builder.Append("CREATE TABLE table_" + pair.Key + " ( ");
                int i = 0;
                foreach (String field in pair.Value)
                {
                    paramsFields.Add("@" + field);
                    String tempfield = "[" + field + "]";
                    insertSqlBuilder.Append(tempfield);
                    selectSqlBuilder.Append(tempfield);
                    builder.Append(tempfield);
                    builder.Append(" memo");
                    i++;
                    if (i == pair.Value.Count)
                        continue;
                    builder.Append(",");
                    insertSqlBuilder.Append(",");
                    selectSqlBuilder.Append(",");
                }
                builder.Append(" )");
                if (!typeSelectSql.ContainsKey(pair.Key))
                    typeSelectSql.Add(pair.Key, String.Format(selectSql, selectSqlBuilder.ToString()));
                if (!typeInsertSql.ContainsKey(pair.Key))
                    typeInsertSql.Add(pair.Key, String.Format(insertSql, insertSqlBuilder.ToString(), String.Join(",", paramsFields)));
                if (!typeSqlParams.ContainsKey(pair.Key))
                    typeSqlParams.Add(pair.Key, paramsFields);
                Console.WriteLine(builder);

                AccessHelper.ExecuteNonQuery(connectionString, builder.ToString());


            }
        }
    }
}
