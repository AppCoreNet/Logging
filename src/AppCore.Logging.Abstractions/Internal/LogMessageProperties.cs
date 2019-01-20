// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using System.Collections;
using System.Collections.Generic;

namespace AppCore.Logging
{
    internal sealed class LogMessageProperties : IReadOnlyList<ILogProperty>
    {
        private readonly LogMessageTemplate _template;
        private readonly object[] _values;

        public static readonly LogMessageProperties Empty = new LogMessageProperties(new LogMessageTemplate(String.Empty), new object[0]);

        public int Count { get; }

        public ILogProperty this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException(nameof(index));

                return LogProperty.Create(_template.VariableNames[index], _values[index]);
            }
        }

        public LogMessageProperties(LogMessageTemplate template, object[] values)
        {
            _template = template;
            Count = values.Length;
            _values = values;
        }

        public IEnumerator<ILogProperty> GetEnumerator()
        {
            for (var i = 0; i < Count; ++i)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal sealed class LogMessageProperties<T0> : IReadOnlyList<ILogProperty>
    {
        private readonly LogMessageTemplate _template;
        private readonly T0 _value0;

        public int Count => 1;

        public ILogProperty this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return LogProperty.Create(_template.VariableNames[0], _value0);
                    default:
                        throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }

        public LogMessageProperties(LogMessageTemplate template, T0 value0)
        {
            _template = template;
            _value0 = value0;
        }

        public IEnumerator<ILogProperty> GetEnumerator()
        {
            for (var i = 0; i < Count; ++i)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal sealed class LogMessageProperties<T0, T1> : IReadOnlyList<ILogProperty>
    {
        private readonly LogMessageTemplate _template;
        private readonly T0 _value0;
        private readonly T1 _value1;

        public int Count => 2;

        public ILogProperty this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return LogProperty.Create(_template.VariableNames[0], _value0);
                    case 1:
                        return LogProperty.Create(_template.VariableNames[1], _value1);
                    default:
                        throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }

        public LogMessageProperties(LogMessageTemplate template, T0 value0, T1 value1)
        {
            _template = template;
            _value0 = value0;
            _value1 = value1;
        }

        public IEnumerator<ILogProperty> GetEnumerator()
        {
            for (var i = 0; i < Count; ++i)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal sealed class LogMessageProperties<T0, T1, T2> : IReadOnlyList<ILogProperty>
    {
        private readonly LogMessageTemplate _template;
        private readonly T0 _value0;
        private readonly T1 _value1;
        private readonly T2 _value2;

        public int Count => 3;

        public ILogProperty this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return LogProperty.Create(_template.VariableNames[0], _value0);
                    case 1:
                        return LogProperty.Create(_template.VariableNames[1], _value1);
                    case 2:
                        return LogProperty.Create(_template.VariableNames[2], _value2);
                    default:
                        throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }

        public LogMessageProperties(LogMessageTemplate template, T0 value0, T1 value1, T2 value2)
        {
            _template = template;
            _value0 = value0;
            _value1 = value1;
            _value2 = value2;
        }

        public IEnumerator<ILogProperty> GetEnumerator()
        {
            for (var i = 0; i < Count; ++i)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal sealed class LogMessageProperties<T0, T1, T2, T3> : IReadOnlyList<ILogProperty>
    {
        private readonly LogMessageTemplate _template;
        private readonly T0 _value0;
        private readonly T1 _value1;
        private readonly T2 _value2;
        private readonly T3 _value3;

        public int Count => 4;

        public ILogProperty this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return LogProperty.Create(_template.VariableNames[0], _value0);
                    case 1:
                        return LogProperty.Create(_template.VariableNames[1], _value1);
                    case 2:
                        return LogProperty.Create(_template.VariableNames[2], _value2);
                    case 3:
                        return LogProperty.Create(_template.VariableNames[3], _value3);
                    default:
                        throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }

        public LogMessageProperties(LogMessageTemplate template, T0 value0, T1 value1, T2 value2, T3 value3)
        {
            _template = template;
            _value0 = value0;
            _value1 = value1;
            _value2 = value2;
            _value3 = value3;
        }

        public IEnumerator<ILogProperty> GetEnumerator()
        {
            for (var i = 0; i < Count; ++i)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal sealed class LogMessageProperties<T0, T1, T2, T3, T4> : IReadOnlyList<ILogProperty>
    {
        private readonly LogMessageTemplate _template;
        private readonly T0 _value0;
        private readonly T1 _value1;
        private readonly T2 _value2;
        private readonly T3 _value3;
        private readonly T4 _value4;

        public int Count => 5;

        public ILogProperty this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return LogProperty.Create(_template.VariableNames[0], _value0);
                    case 1:
                        return LogProperty.Create(_template.VariableNames[1], _value1);
                    case 2:
                        return LogProperty.Create(_template.VariableNames[2], _value2);
                    case 3:
                        return LogProperty.Create(_template.VariableNames[3], _value3);
                    case 4:
                        return LogProperty.Create(_template.VariableNames[4], _value4);
                    default:
                        throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }

        public LogMessageProperties(LogMessageTemplate template, T0 value0, T1 value1, T2 value2, T3 value3, T4 value4)
        {
            _template = template;
            _value0 = value0;
            _value1 = value1;
            _value2 = value2;
            _value3 = value3;
            _value4 = value4;
        }

        public IEnumerator<ILogProperty> GetEnumerator()
        {
            for (var i = 0; i < Count; ++i)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}