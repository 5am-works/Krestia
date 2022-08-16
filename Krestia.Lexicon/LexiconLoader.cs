using System.Reflection;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Krestia.Lexicon; 

public static class LexiconLoader {
   public static Lexicon Load() {
      var deserializer = new DeserializerBuilder()
         .WithNamingConvention(UnderscoredNamingConvention.Instance)
         .Build();
      var file = Assembly.GetExecutingAssembly().GetManifestResourceStream("Krestia.Lexicon.lexicon.yaml");
      return deserializer.Deserialize<Lexicon>(new StreamReader(file!));
   }
}