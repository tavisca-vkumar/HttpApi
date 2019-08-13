using HttpApi.Controllers;
using System;
using Xunit; 

namespace HttpApi.Tests
{
    public class UnitTest1
    {
        ValuesController myApi = new ValuesController();
        [Fact]
        public void return_hi_for_input_hello()
        {
            Assert.Equal("hello",myApi.Get("hi").Value);
        }
        [Fact]
        public void return_hello_for_input_hi()
        {
            var myApi = new ValuesController();
            Assert.Equal("hi", myApi.Get("hello").Value);

        }
        [Fact]
        public void test_for_random_input()
        {
            var myApi = new ValuesController();
            Assert.Equal("don't understand", myApi.Get("random input").Value);

        }
    }
}
