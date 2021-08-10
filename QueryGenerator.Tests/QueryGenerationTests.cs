using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueryGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryGenerator.Tests
{
    [TestClass]
    public class QueryGenerationTests
    {
        [TestMethod]
        public void TestGenerateQueryWithOperatorIN()
        {
            //Arrange 
            List<Column> columns = new List<Column>();
            columns.Add(new Column()
            {
                FieldName = "Column1",
                FieldValue = "value1",
                Operator = "IN"
            });

            Table tblInput = new Table()
            {
                TableName = "Table1",
                Columns = columns
            };

            //Act
            var queryGenerator = new QueryGenerator();
            var result = queryGenerator.GenerateQuery(tblInput);

            //Assert
            Assert.AreEqual(result,"select * from Table1 Where Column1 IN (value1)");
        }
        [TestMethod]
        public void TestGenerateQueryWithOperatorINMultipleValues()
        {
            //Arrange 
            List<Column> columns = new List<Column>();
            columns.Add(new Column()
            {
                FieldName = "Column1",
                FieldValue = "value1;value2;value3",
                Operator = "IN"
            });

            Table tblInput = new Table()
            {
                TableName = "Table1",
                Columns = columns
            };

            //Act
            var queryGenerator = new QueryGenerator();
            var result = queryGenerator.GenerateQuery(tblInput);

            //Assert
            Assert.AreEqual(result, "select * from Table1 Where Column1 IN (value1,value2,value3)");
        }
        [TestMethod]
        public void TestGenerateQueryWithOperatorBetween()
        {
            //Arrange 
            List<Column> columns = new List<Column>();
            columns.Add(new Column()
            {
                FieldName = "Column1",
                FieldValue = "value1;value2",
                Operator = "BETWEEN"
            });

            Table tblInput = new Table()
            {
                TableName = "Table1",
                Columns = columns
            };

            //Act
            var queryGenerator = new QueryGenerator();
            var result = queryGenerator.GenerateQuery(tblInput);

            //Assert
            Assert.AreEqual(result, "select * from Table1 Where Column1 BETWEEN value1 AND value2");
        }
        [TestMethod]
        public void TestGenerateQueryWithLeftJoin()
        {
            //Arrange 
            List<Column> columns = new List<Column>();
            List<Join> joins = new List<Join>();
            columns.Add(new Column()
            {
                FieldName = "Column1",
                FieldValue = "value1;value2",
                Operator = "BETWEEN"
            });

            joins.Add(new Join()
            {
                JoinByColumn = "Column1",
                PrimaryColumnName = "Column1",
                SecondaryTableName = "Table2",
                Type = "LEFT"
            });
            Table tblInput = new Table()
            {
                TableName = "Table1",
                Columns = columns
            };
            TableJoin tblJoinInput = new TableJoin()
            {
                PrimaryTable = tblInput,
                Joins = joins
            };

            //Act
            var queryGenerator = new QueryGenerator();
            var result = queryGenerator.GenerateJoinQuery(tblJoinInput);

            //Assert
            Assert.AreEqual(result, "select * from Table1 LEFT JOIN Table2 ON Table2.Column1 = Table1.Column1");
        }

        [TestMethod]
        public void TestGenerateQueryWithRightJoin()
        {
            //Arrange 
            List<Column> columns = new List<Column>();
            List<Join> joins = new List<Join>();
            columns.Add(new Column()
            {
                FieldName = "Column1",
                FieldValue = "value1;value2",
                Operator = "BETWEEN"
            });

            joins.Add(new Join()
            {
                JoinByColumn = "Column1",
                PrimaryColumnName = "Column1",
                SecondaryTableName = "Table2",
                Type = "RIGHT"
            });
            Table tblInput = new Table()
            {
                TableName = "Table1",
                Columns = columns
            };
            TableJoin tblJoinInput = new TableJoin()
            {
                PrimaryTable = tblInput,
                Joins = joins
            };

            //Act
            var queryGenerator = new QueryGenerator();
            var result = queryGenerator.GenerateJoinQuery(tblJoinInput);

            //Assert
            Assert.AreEqual(result, "select * from Table1 RIGHT JOIN Table2 ON Table2.Column1 = Table1.Column1");
        }        
    }
}
