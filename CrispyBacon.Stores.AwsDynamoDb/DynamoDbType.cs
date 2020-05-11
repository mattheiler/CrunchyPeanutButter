using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Amazon.DynamoDBv2.Model;

namespace CrispyBacon.Stores.AwsDynamoDb
{
    public class DynamoDbType
    {
        private static Dictionary<string, AttributeValue> GetValues(IEnumerable<PropertyInfo> members, object entity)
        {
            return members.ToDictionary(member => member.Name, member => new AttributeValue(member.GetValue(entity)?.ToString()));
        }

        public Type Type { get; }

        public IList<PropertyInfo> Keys { get; }

        public IList<PropertyInfo> Properties { get; }

        public static DynamoDbType For(Type type)
        {
            var keys = new List<PropertyInfo>();
            var properties = new List<PropertyInfo>();
            foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                // TODO get key from config
                if (property.IsDefined(typeof(KeyAttribute)) || property.Name == "Id")
                    keys.Add(property);
                else
                    properties.Add(property);
            }
            var config = new DynamoDbType(type, keys, properties);
            return config;
        }

        public DynamoDbType(Type type, IList<PropertyInfo> keys, IList<PropertyInfo> properties)
        {
            Type = type;
            Keys = keys;
            Properties = properties;
        }

        public string GetTableName()
        {
            return Type.GetCustomAttribute<TableAttribute>()?.Name ?? Type.Name;
        }

        public IEnumerable<PropertyInfo> GetMembers()
        {
            return Properties.Concat(Keys);
        }

        public Dictionary<string, AttributeValue> GetObjectKey(object entity)
        {
            return GetValues(Keys, entity);
        }

        public Dictionary<string, AttributeValue> GetObjectMembers(object entity)
        {
            return GetValues(GetMembers(), entity);
        }

        public Dictionary<string, AttributeValue> GetObjectProperties(object entity)
        {
            return GetValues(Properties, entity);
        }

        public Dictionary<string, AttributeValue> GetKey(params object[] values)
        {
            var keys = new Dictionary<string, AttributeValue>();
            using var entry = Keys.GetEnumerator();
            for (var index = 0; entry.MoveNext(); index++)
            {
                var key = entry.Current;
                if (key == null)
                    throw new InvalidOperationException("Nope.");
                keys[key.Name] = new AttributeValue(values[index].ToString());
            }
            return keys;
        }

        public string GetUpdateExpression(object entity)
        {
            throw new NotImplementedException();
        }

        public object GetModel(Dictionary<string, AttributeValue> item)
        {
            throw new NotImplementedException();
        }

        public string GetQuery<T>(Expression<Func<T, bool>> query)
        {
            throw new NotImplementedException();
        }
    }
}