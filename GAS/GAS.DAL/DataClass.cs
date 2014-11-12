﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GAS.DAL
{
    public class DataClass
    {
        #region 定义与实例化
        BaseClass baseClass=new BaseClass();
        #endregion


        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="Name">姓名</param>
        /// <param name="Pass">密码</param>
        /// <returns>check结果</returns>
        public bool[] LoginChek(string Name, string Pass)
        {
            bool[] ifcom=new bool[2];
            SqlDataReader temDR = baseClass.getcom("select * from UserPope where Name='" + Name + "' and Pass='" + Pass + "'");
            ifcom[0] = temDR.Read();
            if (ifcom[0])
            { 
                //Boolean i = temDR.GetBoolean(4);
                ifcom[1] = temDR.GetBoolean(4);

                baseClass.My_con.Close();
                baseClass.My_con.Dispose();
            }
            baseClass.con_close();
            return ifcom;
        }

        /// <summary>
        /// 测试数据库连接
        /// </summary>
        public void TestCon()
        {
            baseClass.con_open();  //连接数据库
            baseClass.con_close();
            
        }

        public DataSet QueryTable(string TableName)
        {
            DataSet returndataset = baseClass.getDataSet("select * from " + TableName, TableName);
            return returndataset;
        
        }

        public DataSet QueryTable(string ClomName, string TableName)
        {
            DataSet returndataset = baseClass.getDataSet("select "+ ClomName +" from " + TableName, TableName);
            return returndataset;

        }
    
    
    }
}
