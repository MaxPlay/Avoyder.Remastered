using System;
using System.Collections.Generic;
using System.Text;

namespace Avoyder.Remastered.Core
{
    public struct Name : IEquatable<Name>, IEquatable<string>
    {
        private readonly ulong identifier;

        public Name(string name)
        {
            identifier = NameContainer.RegisterName(name);
        }

        public static Name Empty { get; } = new Name(string.Empty);

        public bool IsValid => NameContainer.IsValid(identifier);

        // We use explicit conversion, because we don't want that happen automatically all the time!
        public static explicit operator Name(string name) => new Name(name);

        public static implicit operator string(Name name) => NameContainer.GetString(name.identifier);

        public bool Equals(Name other) => other.identifier == identifier;

        public bool Equals(string other) => NameContainer.GetId(other) == identifier;

        public override string ToString() => this;
    }

    internal static class NameContainer
    {
        private const int NAME_NULL_ID = 0;
        private const string NAME_NULL_STRING = "";
        private static readonly Dictionary<ulong, string> idToStringEntries = new Dictionary<ulong, string>();
        private static readonly Dictionary<string, ulong> stringToIdEntries = new Dictionary<string, ulong>();

        internal static ulong GetId(string value) => stringToIdEntries.ContainsKey(value) ? stringToIdEntries[value] : NAME_NULL_ID;

        internal static string GetString(ulong value) => idToStringEntries.ContainsKey(value) ? idToStringEntries[value] : NAME_NULL_STRING;

        internal static bool IsValid(ulong identifier) => identifier != NAME_NULL_ID;

        internal static ulong RegisterName(string value)
        {
            if (value.Length == 0)
                return NAME_NULL_ID;

            if (stringToIdEntries.ContainsKey(value))
                return stringToIdEntries[value];

            ulong identifier = Hash(value);
            stringToIdEntries.Add(value, identifier);
            idToStringEntries.Add(identifier, value);
            return identifier;
        }

        // Note: This is a simple hash function based on this answer on stackoverflow by the epic
        //       Jon Skeet: https://stackoverflow.com/a/5155015/5593150 I changed it to use an
        //       unsigned 64 bit integer, to make possible collisions even less likely
        private static ulong Hash(string value)
        {
            if (value == null || value.Length == 0)
                return NAME_NULL_ID;

            unchecked
            {
                ulong hash = 23;
                for (int i = 0; i < value.Length; i++)
                {
                    hash = hash * 31 + value[i];
                }
                return hash;
            }
        }
    }
}
