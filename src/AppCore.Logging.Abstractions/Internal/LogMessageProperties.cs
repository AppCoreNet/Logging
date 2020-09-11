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

        public static readonly LogMessageProperties Empty =
            new LogMessageProperties(new LogMessageTemplate(string.Empty), new object[0]);

        public int Count { get; }

        public ILogProperty this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException(nameof(index));

                object value = _values[index];
                if (value is ILogProperty logProperty)
                    return logProperty;

                return LogProperty.Create(_template.VariableNames[index], value);
            }
        }

        public LogMessageProperties(LogMessageTemplate template, object[] values)
        {
            _template = template;
            _values = values;

            Count = values.Length;
        }

        public IEnumerator<ILogProperty> GetEnumerator()
        {
            for (int i = 0; i < Count; ++i)
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
        private const int ValueCount = 1;
        private readonly LogMessageTemplate _template;
        private readonly T0 _value0;
        private readonly IReadOnlyList<ILogProperty> _extraProperties;

        public int Count => ValueCount + _extraProperties.Count;

        public ILogProperty this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return LogProperty.Create(_template.VariableNames[0], _value0);

                    case { } index2 when index2 > 0 && index2 - ValueCount < _extraProperties.Count:
                        return _extraProperties[index2 - ValueCount];

                    default:
                        throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }

        public LogMessageProperties(LogMessageTemplate template, T0 value0, IReadOnlyList<ILogProperty> extraProperties)
        {
            _template = template;
            _value0 = value0;
            _extraProperties = extraProperties;
        }

        public IEnumerator<ILogProperty> GetEnumerator()
        {
            for (int i = 0; i < Count; ++i)
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
        private const int ValueCount = 2;
        private readonly LogMessageTemplate _template;
        private readonly T0 _value0;
        private readonly T1 _value1;
        private readonly IReadOnlyList<ILogProperty> _extraProperties;

        public int Count => ValueCount + _extraProperties.Count;

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
                    case { } index2 when index2 > 0 && index2 - ValueCount < _extraProperties.Count:
                        return _extraProperties[index2 - ValueCount];
                    default:
                        throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }

        public LogMessageProperties(
            LogMessageTemplate template,
            T0 value0,
            T1 value1,
            IReadOnlyList<ILogProperty> extraProperties)
        {
            _template = template;
            _value0 = value0;
            _value1 = value1;
            _extraProperties = extraProperties;
        }

        public IEnumerator<ILogProperty> GetEnumerator()
        {
            for (int i = 0; i < Count; ++i)
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
        private const int ValueCount = 3;
        private readonly LogMessageTemplate _template;
        private readonly T0 _value0;
        private readonly T1 _value1;
        private readonly T2 _value2;
        private readonly IReadOnlyList<ILogProperty> _extraProperties;

        public int Count => ValueCount + _extraProperties.Count;

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
                    case { } index2 when index2 > 0 && index2 - ValueCount < _extraProperties.Count:
                        return _extraProperties[index2 - ValueCount];
                    default:
                        throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }

        public LogMessageProperties(
            LogMessageTemplate template,
            T0 value0,
            T1 value1,
            T2 value2,
            IReadOnlyList<ILogProperty> extraProperties)
        {
            _template = template;
            _value0 = value0;
            _value1 = value1;
            _value2 = value2;
            _extraProperties = extraProperties;
        }

        public IEnumerator<ILogProperty> GetEnumerator()
        {
            for (int i = 0; i < Count; ++i)
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
        private const int ValueCount = 4;
        private readonly LogMessageTemplate _template;
        private readonly T0 _value0;
        private readonly T1 _value1;
        private readonly T2 _value2;
        private readonly T3 _value3;
        private readonly IReadOnlyList<ILogProperty> _extraProperties;

        public int Count => ValueCount + _extraProperties.Count;

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
                    case { } index2 when index2 > 0 && index2 - ValueCount < _extraProperties.Count:
                        return _extraProperties[index2 - ValueCount];
                    default:
                        throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }

        public LogMessageProperties(
            LogMessageTemplate template,
            T0 value0,
            T1 value1,
            T2 value2,
            T3 value3,
            IReadOnlyList<ILogProperty> extraProperties)
        {
            _template = template;
            _value0 = value0;
            _value1 = value1;
            _value2 = value2;
            _value3 = value3;
            _extraProperties = extraProperties;
        }

        public IEnumerator<ILogProperty> GetEnumerator()
        {
            for (int i = 0; i < Count; ++i)
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
        private const int ValueCount = 5;
        private readonly LogMessageTemplate _template;
        private readonly T0 _value0;
        private readonly T1 _value1;
        private readonly T2 _value2;
        private readonly T3 _value3;
        private readonly T4 _value4;
        private readonly IReadOnlyList<ILogProperty> _extraProperties;

        public int Count => ValueCount + _extraProperties.Count;

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
                    case { } index2 when index2 > 0 && index2 - ValueCount < _extraProperties.Count:
                        return _extraProperties[index2 - ValueCount];
                    default:
                        throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }

        public LogMessageProperties(
            LogMessageTemplate template,
            T0 value0,
            T1 value1,
            T2 value2,
            T3 value3,
            T4 value4,
            IReadOnlyList<ILogProperty> extraProperties)
        {
            _template = template;
            _value0 = value0;
            _value1 = value1;
            _value2 = value2;
            _value3 = value3;
            _value4 = value4;
            _extraProperties = extraProperties;
        }

        public IEnumerator<ILogProperty> GetEnumerator()
        {
            for (int i = 0; i < Count; ++i)
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