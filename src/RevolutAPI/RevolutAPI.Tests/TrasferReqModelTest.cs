using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using RevolutAPI.Models.BusinessApi.Payment;
using RevolutAPI.Tests.Utils;
using Xunit;

namespace RevolutAPI.Tests
{
    public class TrasferReqModelTest
    {
        private readonly TransferReq BASE_MODEL;

        public TrasferReqModelTest()
        {
            // filled with valid data
            BASE_MODEL = new TransferReq
            {
                RequestId = "111",
                SourceAccountId = "source",
                TargetAccountId = "target",
                Amount = 1.0,
                Currency = "123",
                Description = "description"
            };
        }
       
        [Fact]
        public void Test_TrasferReq_ValidModel()
        {
            Assert.True(ModelValidator.IsValid(BASE_MODEL));
        }
        
        [Fact]
        public void Test_TrasferReq_RequestId_ValidLength()
        {
            string requestId = new string('*', 30);
            BASE_MODEL.RequestId = requestId;
            Assert.True(ModelValidator.IsValid(BASE_MODEL));
        }
        
        [Fact]
        public void Test_TrasferReq_RequestId_InvalidLength()
        {
            string requestId = new string('*', 31);
            BASE_MODEL.RequestId = requestId;
            Assert.False(ModelValidator.IsValid(BASE_MODEL));
        }
    }
}