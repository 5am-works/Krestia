require "yaml"

lexicon = YAML.load_file("lexicon.yaml")
output = StringIO.new

output << %{
module Krestia.Core.Lexicon.Lexicon

open Krestia.Core.Lexicon.Types
open Krestia.Core.Lexicon.LexiconHelpers

let lexicon =
   lexicon \{
}

lexicon.each do |word_type, words|
   if word_type == 'related_words'
      next
   end

   words.each do |word|
      extra_keys = word.keys - ["spelling", "meaning"]
      if extra_keys.empty?
         output << "      word \"#{word["spelling"]}\" { meaning \"#{word["meaning"]}\" }\n"
      else
         output << "      word \"#{word["spelling"]}\" {\n"
         output << "         meaning \"#{word["meaning"]}\"\n"
         extra_keys.each do |key|
            case key
            when "quantified_meaning"
               output << "         quantified \"#{word[key]}\"\n"
            when "expanded_form"
               output << "         expanded \"#{word[key]}\"\n"
            when "domains"
               output << "         domains #{word[key]}\n"
            when "example_usages"
               word[key].each do |example|
                  output << "         example\n"
                  output << "            \"#{example["text"]}\"\n"
                  output << "            \"#{example["translation"]}\"\n"
               end
            when "roots"
               # TODO
            else
               output << "         #{key} \"#{word[key]}\"\n"
            end
         end
         output << "      }\n"
      end
   end
end

output << "   }

let printLexicon () = printfn $\"{lexicon}\"
"

File.open("Lexicon2.fs", "w") { |file| file << output.string }