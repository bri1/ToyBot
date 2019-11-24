using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
[assembly: CollectionBehavior(CollectionBehavior.CollectionPerClass, DisableTestParallelization = true)]

namespace Bot1.Tests
{
    public class BaseTest
    {

        protected readonly Bot _testBot; //only ever making changes to it in the constructor

        public BaseTest()
        {
            _testBot = new Bot();
        }
    }
}
