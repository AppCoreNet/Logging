// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using Xunit;

namespace AppCore.Logging
{
    public class LoggerMessageTemplateTests
    {
        [Fact]
        public void Parses_VariablesNames_From_CurlyBraces()
        {
            var template = new LogMessageTemplate("abc {value1} defg {value2}");
            Assert.Equal(new[] {"value1", "value2"}, template.VariableNames);
        }

        [Fact]
        public void Ignores_VariableNames_In_DoubleCurlyBraces()
        {
            var template = new LogMessageTemplate("abc {value1} defg {{value2}}");
            Assert.Equal(new[] { "value1" }, template.VariableNames);
        }
    }
}
