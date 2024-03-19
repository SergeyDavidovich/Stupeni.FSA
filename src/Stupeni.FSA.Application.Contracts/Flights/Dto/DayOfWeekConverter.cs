using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Stupeni.FSA.Flights.Dto
{
    /// <summary>
    /// Преобразователь JSON для List<DayOfWeek> и обратно в JSON
    /// </summary>
    public class DayOfWeekConverter : JsonConverter<List<DayOfWeek>>
    {
        public override List<DayOfWeek> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
                throw new JsonException("Expected StartArray token");

            var daysOfWeek = new List<DayOfWeek>();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndArray)
                    return daysOfWeek;

                if (reader.TokenType == JsonTokenType.String)
                {
                    if (Enum.TryParse<DayOfWeek>(reader.GetString(), out var dayOfWeek))
                        daysOfWeek.Add(dayOfWeek);
                    else
                        throw new JsonException($"Invalid day of week: {reader.GetString()}");
                }
                else
                    throw new JsonException($"Unexpected token type: {reader.TokenType}");
            }

            throw new JsonException("Unexpected end of JSON input");
        }

        public override void Write(Utf8JsonWriter writer, List<DayOfWeek> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();

            foreach (var dayOfWeek in value)
            {
                writer.WriteStringValue(dayOfWeek.ToString());
            }

            writer.WriteEndArray();
        }
    }
}