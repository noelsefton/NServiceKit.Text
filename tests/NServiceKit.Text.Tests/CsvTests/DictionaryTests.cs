﻿using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace NServiceKit.Text.Tests.CsvTests
{
    /// <summary>A dictionary tests.</summary>
    [TestFixture]
    public class DictionaryTests
    {
        /// <summary>Serializes dictionary mismatched keys deserializes tabular CSV.</summary>
        [Test]
        public void Serializes_dictionary_mismatched_keys_deserializes_tabular_csv()
        {
            var data = new List<Dictionary<string, string>> {
                new Dictionary<string, string> { {"Column2Data", "Like"}, {"Column3Data", "To"}, {"Column4Data", "Read"}, {"Column5Data", "Novels"}},
                new Dictionary<string, string> { { "Column1Data", "I am" }, {"Column3Data", "Cool"}, {"Column4Data", "And"}, {"Column5Data", "Awesome"}},
                new Dictionary<string, string> { { "Column1Data", "I" }, {"Column2Data", " Like "}, {"Column4Data", null}, {"Column5Data", null}},
                new Dictionary<string, string> { { "Column1Data", "I" }, {"Column2Data", "Don't"}, {"Column3Data", "Know,"}, {"Column5Data", "You?"}},
                new Dictionary<string, string> { { "Column1Data", "I" }, {"Column2Data", "Saw"}, {"Column3Data", "The"}, {"Column4Data", "Movie"}},
                new Dictionary<string, string> { { "Column1Data", "I" }, {"Column2Data", "Went"}, {"Column3Data", "To"}, {"Column4Data", "Space\nCamp"}, {"Column5Data", "Last\r\nYear"}}
			};

            var csv = CsvSerializer.SerializeToCsv(data);

            Assert.That(csv, Is.EqualTo(
                "Column1Data,Column2Data,Column3Data,Column4Data,Column5Data"
                + Environment.NewLine
                + ",Like,To,Read,Novels"
                + Environment.NewLine
                + "I am,,Cool,And,Awesome"
                + Environment.NewLine
                + "I, Like ,,,"
                + Environment.NewLine
                + "I,Don't,\"Know,\",,You?"
                + Environment.NewLine
                + "I,Saw,The,Movie,"
                + Environment.NewLine
                + "I,Went,To,\"Space\nCamp\",\"Last\r\nYear\""
                + Environment.NewLine
            ));
        }

        /// <summary>Serializes dictionary data.</summary>
        [Test]
        public void Serializes_dictionary_data()
        {
            var data = new List<Dictionary<string, string>> {
                new Dictionary<string, string> { { "Column1Data", "I" }, {"Column2Data", "Like"}, {"Column3Data", "To"}, {"Column4Data", "Read"}, {"Column5Data", "Novels"}},
                new Dictionary<string, string> { { "Column1Data", "I am" }, {"Column2Data", "Very"}, {"Column3Data", "Cool"}, {"Column4Data", "And"}, {"Column5Data", "Awesome"}},
                new Dictionary<string, string> { { "Column1Data", "I" }, {"Column2Data", " Like "}, {"Column3Data", "Reading"}, {"Column4Data", null}, {"Column5Data", null}},
                new Dictionary<string, string> { { "Column1Data", "I" }, {"Column2Data", "Don't"}, {"Column3Data", "Know,"}, {"Column4Data", "Do"}, {"Column5Data", "You?"}},
                new Dictionary<string, string> { { "Column1Data", "I" }, {"Column2Data", "Saw"}, {"Column3Data", "The"}, {"Column4Data", "Movie"}, {"Column5Data", "\"Jaws\""}},
                new Dictionary<string, string> { { "Column1Data", "I" }, {"Column2Data", "Went"}, {"Column3Data", "To"}, {"Column4Data", "Space\nCamp"}, {"Column5Data", "Last\r\nYear"}}
			};

            var csv = CsvSerializer.SerializeToCsv(data);

            Assert.That(csv, Is.EqualTo(
                "Column1Data,Column2Data,Column3Data,Column4Data,Column5Data"
                + Environment.NewLine
                + "I,Like,To,Read,Novels"
                + Environment.NewLine
                + "I am,Very,Cool,And,Awesome"
                + Environment.NewLine
                + "I, Like ,Reading,,"
                + Environment.NewLine
                + "I,Don't,\"Know,\",Do,You?"
                + Environment.NewLine
                + "I,Saw,The,Movie,\"\"\"Jaws\"\"\""
                + Environment.NewLine
                + "I,Went,To,\"Space\nCamp\",\"Last\r\nYear\""
                + Environment.NewLine
            ));
        }

        /// <summary>Serializes dictionary object data.</summary>
        [Test]
        public void Serializes_dictionary_object_data()
        {
            var data = new List<Dictionary<string, object>>
                           {
                               new Dictionary<string, object>
                                   {
                                       {"Column1Data", "I"},
                                       {"Column2Data", "Like"},
                                       {"Column3Data", "To"},
                                       {"Column4Data", "Read"},
                                       {"Column5Data", 123}
                                   },
                               new Dictionary<string, object>
                                   {
                                       {"Column1Data", "I am"},
                                       {"Column2Data", "Very"},
                                       {"Column3Data", "Cool"},
                                       {"Column4Data", "And"},
                                       {"Column5Data", 4}
                                   },
                               new Dictionary<string, object>
                                   {
                                       {"Column1Data", "I"},
                                       {"Column2Data", " Like "},
                                       {"Column3Data", 2},
                                       {"Column4Data", null},
                                       {"Column5Data", null}
                                   },
                               new Dictionary<string, object>
                                   {
                                       {"Column1Data", "I"},
                                       {"Column2Data", "Don't"},
                                       {"Column3Data", "Know,"},
                                       {"Column4Data", "Do"},
                                       {"Column5Data", "You?"}
                                   },
                               new Dictionary<string, object>
                                   {
                                       {"Column1Data", "I"},
                                       {"Column2Data", "Saw"},
                                       {"Column3Data", "The"},
                                       {"Column4Data", "Movie"},
                                       {"Column5Data", "\"Jaws\""}
                                   },
                               new Dictionary<string, object>
                                   {
                                       {"Column1Data", "I"},
                                       {"Column2Data", "Went"},
                                       {"Column3Data", "To"},
                                       {"Column4Data", "Space\nCamp"},
                                       {"Column5Data", "Last\r\nYear"}
                                   }
                           };

            var csv = CsvSerializer.SerializeToCsv(data);

            Assert.That(csv, Is.EqualTo(
                "Column1Data,Column2Data,Column3Data,Column4Data,Column5Data"
                + Environment.NewLine
                + "I,Like,To,Read,123"
                + Environment.NewLine
                + "I am,Very,Cool,And,4"
                + Environment.NewLine
                + "I, Like ,2,,"
                + Environment.NewLine
                + "I,Don't,\"Know,\",Do,You?"
                + Environment.NewLine
                + "I,Saw,The,Movie,\"\"\"Jaws\"\"\""
                + Environment.NewLine
                + "I,Went,To,\"Space\nCamp\",\"Last\r\nYear\""
                + Environment.NewLine
                                 ));
        }

        /// <summary>Tear down.</summary>
        [TearDown]
        public void TearDown()
        {
            CsvConfig.Reset();
        }

        /// <summary>Serializes dictionary data long delimiter.</summary>
        [Test]
        public void Serializes_dictionary_data_long_delimiter()
        {
            CsvConfig.ItemDelimiterString = "^~^";
            var data = new List<Dictionary<string, string>> {
                new Dictionary<string, string> { { "Column1Data", "I" }, {"Column2Data", "Like"}, {"Column3Data", "To"}, {"Column4Data", "Read"}, {"Column5Data", "Novels"}},
                new Dictionary<string, string> { { "Column1Data", "I am" }, {"Column2Data", "Very"}, {"Column3Data", "Cool"}, {"Column4Data", "And"}, {"Column5Data", "Awesome"}},
                new Dictionary<string, string> { { "Column1Data", "I" }, {"Column2Data", " Like "}, {"Column3Data", "Reading"}, {"Column4Data", null}, {"Column5Data", null}},
                new Dictionary<string, string> { { "Column1Data", "I" }, {"Column2Data", "Don't"}, {"Column3Data", "Know,"}, {"Column4Data", "Do"}, {"Column5Data", "You?"}},
                new Dictionary<string, string> { { "Column1Data", "I" }, {"Column2Data", "Saw"}, {"Column3Data", "The"}, {"Column4Data", "Movie"}, {"Column5Data", "\"Jaws\""}},
                new Dictionary<string, string> { { "Column1Data", "I" }, {"Column2Data", "Went"}, {"Column3Data", "To"}, {"Column4Data", "Space\nCamp"}, {"Column5Data", "Last\r\nYear"}}
			};

            var csv = CsvSerializer.SerializeToCsv(data);

            Assert.That(csv, Is.EqualTo(
                "Column1Data,Column2Data,Column3Data,Column4Data,Column5Data"
                + Environment.NewLine
                + "I,Like,To,Read,Novels"
                + Environment.NewLine
                + "I am,Very,Cool,And,Awesome"
                + Environment.NewLine
                + "I, Like ,Reading,,"
                + Environment.NewLine
                + "I,Don't,^~^Know,^~^,Do,You?"
                + Environment.NewLine
                + "I,Saw,The,Movie,\"Jaws\""
                + Environment.NewLine
                + "I,Went,To,^~^Space\nCamp^~^,^~^Last\r\nYear^~^"
                + Environment.NewLine
            ));
        }

        /// <summary>Serializes dictionary data pipe separator.</summary>
        [Test]
        public void Serializes_dictionary_data_pipe_separator()
        {
            CsvConfig.ItemSeperatorString = "|";
            var data = new List<Dictionary<string, string>> {
                new Dictionary<string, string> { { "Column1Data", "I" }, {"Column2Data", "Like"}, {"Column3Data", "To"}, {"Column4Data", "Read"}, {"Column5Data", "Novels"}},
                new Dictionary<string, string> { { "Column1Data", "I am" }, {"Column2Data", "Very"}, {"Column3Data", "Cool"}, {"Column4Data", "And"}, {"Column5Data", "Awesome"}},
                new Dictionary<string, string> { { "Column1Data", "I" }, {"Column2Data", " Like "}, {"Column3Data", "Reading"}, {"Column4Data", null}, {"Column5Data", null}},
                new Dictionary<string, string> { { "Column1Data", "I" }, {"Column2Data", "Don't"}, {"Column3Data", "Know,"}, {"Column4Data", "Do"}, {"Column5Data", "You?"}},
                new Dictionary<string, string> { { "Column1Data", "I" }, {"Column2Data", "Saw"}, {"Column3Data", "The"}, {"Column4Data", "Movie"}, {"Column5Data", "\"Jaws\""}},
                new Dictionary<string, string> { { "Column1Data", "I" }, {"Column2Data", "Went"}, {"Column3Data", "To"}, {"Column4Data", "Space\nCamp"}, {"Column5Data", "Last\r\nYear"}}
			};

            var csv = CsvSerializer.SerializeToCsv(data);

            Assert.That(csv, Is.EqualTo(
                "Column1Data|Column2Data|Column3Data|Column4Data|Column5Data"
                + Environment.NewLine
                + "I|Like|To|Read|Novels"
                + Environment.NewLine
                + "I am|Very|Cool|And|Awesome"
                + Environment.NewLine
                + "I| Like |Reading||"
                + Environment.NewLine
                + "I|Don't|Know,|Do|You?"
                + Environment.NewLine
                + "I|Saw|The|Movie|\"\"\"Jaws\"\"\""
                + Environment.NewLine
                + "I|Went|To|\"Space\nCamp\"|\"Last\r\nYear\""
                + Environment.NewLine
            ));
        }
    }
}
