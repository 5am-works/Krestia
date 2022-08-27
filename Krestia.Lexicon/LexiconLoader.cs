using System.Reflection;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Krestia.Lexicon;

public static class LexiconLoader {
   private static readonly Lazy<Lexicon> Instance = new(Load);
   public static Lexicon LexiconInstance => Instance.Value;

   private static Lexicon Load() {
      var deserializer = new DeserializerBuilder()
         .WithNamingConvention(UnderscoredNamingConvention.Instance)
         .Build();
      var file = Assembly.GetExecutingAssembly()
         .GetManifestResourceStream("Krestia.Lexicon.lexicon.yaml");
      return deserializer.Deserialize<Lexicon>(new StreamReader(file!));
   }
}