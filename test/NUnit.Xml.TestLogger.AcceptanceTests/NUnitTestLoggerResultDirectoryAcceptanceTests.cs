﻿// Copyright (c) Spekt Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace NUnit.Xml.TestLogger.AcceptanceTests
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class NUnitTestLoggerResultDirectoryAcceptanceTests
    {
        [ClassInitialize]
        public static void SuiteInitialize(TestContext context)
        {
            DotnetTestFixture.RootDirectory = Path.GetFullPath(
                    Path.Combine(
                        Environment.CurrentDirectory,
                        "..",
                        "..",
                        "..",
                        "..",
                        "assets",
                        "NUnit.Xml.TestLogger.NetCore.Tests"));
            DotnetTestFixture.TestAssemblyName = "NUnit.Xml.TestLogger.NetCore.Tests.dll";
            var testResultsPath = Path.Combine(DotnetTestFixture.RootDirectory, "artifacts");
            DotnetTestFixture.Execute("test-results.xml", testResultsPath);
        }

        [TestMethod]
        public void TestRunWithResultDirectoryAndFileNameShouldCreateResultsFile()
        {
            var expectedResultsPath = Path.Combine(DotnetTestFixture.RootDirectory, "artifacts", "test-results.xml");
            Assert.IsTrue(File.Exists(expectedResultsPath), $"Results file at '{expectedResultsPath}' not found.");
        }
    }
}
