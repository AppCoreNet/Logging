using System.Collections.Concurrent;
using Serilog.Events;
using Serilog.Parsing;

namespace AppCore.Logging
{
    internal class MessageTemplateCache
    {
        private static readonly MessageTemplateParser TemplateParser = new MessageTemplateParser();

        private readonly ConcurrentDictionary<string, MessageTemplate> _templates =
            new ConcurrentDictionary<string, MessageTemplate>();

        public MessageTemplate Get(LogMessageTemplate template)
        {
            return _templates.GetOrAdd(template.Format, t => TemplateParser.Parse(t));
        }
    }
}