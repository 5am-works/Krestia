module Krestia.Parser.Lexicon

open Krestia.Parser.WordType
open Krestia.Parser.Internals.Dictionary

let dictionary = lexicon {
   noun "almeki" "healthy, well" "healthy" []
   noun "ameme" "ambient temperature" "temperature" []
   noun "avelme" "something, someone" "something" []
   noun "avilma" "everything, all" "everything" []
   noun "avolma" "what" "what" [] "Putting this into a sentence turns it into a question"
   noun "bedreke" "warm" "warm" [] "Refers to temperatures between 20°C and 30°C"
   noun "beledriki" "scorching hot" "hot" [] "Refers to temperatures above 40°C"
   noun "beleta" "stove, oven, cooking heat source" "stove" ["beledriki"]
   noun "belime" "wind" "wind" ["bet"; "gelume"]
   noun "belpe" "circle" "circle" []
   noun "benidreta" "hot" "hot" [] "Refers to temperatures between 30°C and 40°C"
   noun "berope" "brisk, cool" "brisk" [] "Refers to temperatures between 10°C and 20°C"
   noun "beseti" "zodiac sign" "zodiac_sign" ["belpe"; "seliti"; "teti"]
   noun "besota" "foul, stinky, bad-smelling" "foul" []
   noun "bileka" "sharp" "sharp" [] "Refers to something that can cut; does not refer to smell or figurative meanings"
   noun "bilepe" "chisel" "chisel" ["bilesop"]
   noun "bimiti" "angry" "angry" []
   noun "bolta" "door" "door" [] "Both sides are inside a building"
   noun "borope" "breath" "breath" ["borop"]
   noun "bota" "nail" "nail" []
   noun "breka" "male" "male" []
   noun "brepe" "boy" "boy" ["breka"]
   noun "brete" "man" "man" ["breka"; "tate"]
   noun "delta" "spot, dot, speck" "spot" []
   noun "demepa" "joyful, glad, happy" "happy" []
   noun "domote" "house" "house" [] "Refers to any kind of dwelling place"
   noun "drelopa" "rough, uneven" "rough" []
   noun "dulete" "glass" "glass" ["duna"]
   noun "dumbete" "clock, timepiece" "clock" ["duna"; "bet"]
   noun "duna" "sand (substance)" "sand" []
   noun "duname" "time" "time" ["duna"] "Refers to the concept of time (i.e. arrow of time) itself"
   noun "elate" "new, novel" "new" ["elita"] "Refers to something that one previously did not know (i.e. a new book = a book that one just obtained)"
   noun "elita" "new, young, recent" "new" [] "Refers to something that has not existed for too long (i.e. a new book = a book that was recently published)"
   noun "emika" "I (singular), we (plural); first-person pronoun" "FIRST_PERSON" []
   noun "emolka" "garden" "garden" []
   noun "ene" "subclause marker indicating the verb as the head" "clause_of" []
   noun "enita" "sheep" "sheep" []
   noun "enote" "chain, shackle" "chain" ["enat"]
   noun "esika" "you; second-person pronoun" "SECOND_PERSON" []
   noun "etika" "he, she, it, they; third-person pronoun" "THIRD_PERSON" []
   noun "gelume" "air" "air" []
   noun "ginite" "cool, refreshingly cold" "cool" [] "Related to \"kenid\" (cold), but refers to a temperature that one would enjoy"
   noun "glineka" "weak" "weak" [] "Refers to physical weakness"
   noun "gliniki" "crab" "crab" []
   noun "golepi" "quiet" "quiet" [] "Refers to sound pressure levels between 30 dB and 50 dB"
   noun "grema" "world" "world" ["gremi"; "vosma"]
   noun "greme" "future" "future" []
   noun "gremi" "sky" "sky" []
   noun "gremune" "weather" "weather" ["gremi"] "Refers to the state of the sky at a given time"
   noun "gremute" "weather condition" "weather" ["gremune"] "Refers to any of the weather conditions, such as rain, sun, etc."
   noun "grike" "female" "female" []
   noun "grite" "woman" "woman" ["grike"; "tate"]
   noun "gromoka" "frequent, recurring" "frequent" []
   noun "grumiki" "bitter" "bitter" []
   noun "imilta" "room" "room" []
   noun "kedrepa" "cold" "cold" [] "Refers to temperatures between -20°C and 0°C"
   noun "keledrike" "extremely cold" "cold" [] "Refers to temperatures below -40°C"
   noun "keleke" "lively loud" "lively" [] "Refers to sound pressure levels between 50 dB and 70 dB"
   noun "keneka" "loud" "loud" [] "Refers to sound pressure levels between 70 dB and 100 dB"
   noun "kenidreki" "unbearably cold" "cold" [] "Refers to temperatures between -40°C and -20°C"
   noun "kenipi" "uncomfortably cold" "cold" [] "Subjectively defined; refers to any temperature that is painful to endure"
   noun "kete" "sound" "sound" [] "Refers to any instance of sound"
   noun "ketete" "extremely loud" "loud" [] "Refers to sound pressure levels between 100 dB and 150 dB"
   noun "kilite" "bull, cow, cattle" "cattle" []
   noun "kirika" "brave, courageous" "brave" []
   noun "kiriki" "danger, dangerous situation" "danger" ["kirika"]
   noun "klesteki" "deafeningly loud" "loud" [] "Refers to sound pressure levels above and including 150 dB"
   noun "kliti" "key (lock)" "key" [] "Refers to the tool used open a lock"
   noun "kluti" "lock" "lock" ["kliti"]
   noun "krelni" "shade,shadow" "shadow" ["krene"; "lini"]
   noun "krena" "dawn, daybreak" "dawn" ["krenit"]
   noun "krene" "light" "light" [] "Refers to visible light"
   noun "krenote" "bright" "bright" ["krene"] "Refers to an abundance of light"
   noun "krenti" "window" "window" ["krene"]
   noun "kresite" "ceiling light" "light" ["krene"]
   noun "kreska" "candle" "candle" ["kreska"]
   noun "kreskene" "lightning" "lightning" ["kresne"; "krene"]
   noun "kreski" "flame" "flame" ["poski"; "krene"] "Refers to the light emitted by fire"
   noun "kresne" "thunder" "thunder" []
   noun "kresnopi" "thunderous" "thunderous" ["kresne"]
   noun "kreste" "lamp, flashlight, torch, localized lighting" "lamp" ["krene"]
   noun "krete" "color, colour" "colour" ["krene"] "Refers to the concept of colours in general, not to any specific colour"
   noun "krite" "this one" "this" []
   noun "kulete" "river" "river" ["leres"; "kuna"]
   noun "kumome" "today" "today" []
   noun "kuna" "water" "water" []
   noun "kunapa" "spring, well" "well" ["kuna"]
   noun "kunape" "wet, damp" "wet" ["kunape"]
   noun "kunata" "ocean,sea" "ocean" ["kuna"]
   noun "kunote" "hard, firm" "hard" [] "Refers to physical hardness, not difficulty"
   noun "kuvosta" "lake" "lake" ["kuna"; "vosma"]
   noun "lemipa" "sorry, regrettable" "regrettable" ["lemit"] "Not used for apologies, which uses \"lomov\" instead"
   noun "leveka" "sad" "sad" []
   noun "likrene" "sunset" "sunset" ["lukrene"; "lite"]
   noun "likuta" "shore" "shore" ["lidre"; "kunata"]
   noun "limita" "pure" "pure" []
   noun "lineki" "peacefully quiet" "quiet" [] "Refers to quietness that is peaceful"
   noun "lineti" "peaceful" "peaceful" ["lineki"]
   noun "lini" "darkness" "darkness" ["linupi"]
   noun "linupi" "black" "black" []
   noun "lipiti" "tired, weary, exhausted" "tired" []
   noun "lipoti" "chair" "chair" []
   noun "lirekuta" "tear (from the eyes)" "tear" ["liredre"; "kuna"]
   noun "lite" "nighttime, night" "night" []
   noun "liveti" "bed" "bed" ["liveras"]
   noun "livopi" "scorpion" "scorpion" []
   noun "lometi" "light (weight)" "light" ["lomika"] "Refers to an object whose weight makes it easy to handle"
   noun "lomika" "light, lightweight" "light" [] "Refers to an object whose weight is below what is expected"
   noun "lukrene" "sunrise" "sunrise" ["luna"; "krene"]
   noun "lukuna" "blood" "blood" ["lukregre"; "kuna"]
   noun "lumite" "beautiful" "beautiful" []
   noun "luna" "sun" "sun" [] "Specifically refers to the star that the Earth orbits"
   noun "lunata" "star" "star" ["luna"] "Refers to the astronomical objects"
   noun "lunome" "summer" "summer" ["luna"]
   noun "lurika" "cloud" "cloud" []
   noun "lutreta" "bone" "bone" ["lukregre"; "treta"]
   noun "luvema" "rain (substance)" "rain" ["luvem"] "Refers to the falling rain itself"
   noun "mamoki" "lazy" "lazy" []
   noun "mebeta" "gate" "gate" [] "At least one side is outside of a building"
   noun "meki" "tree" "tree" []
   noun "melmote" "yard, court" "yard" []
   noun "memeki" "forest, woods" "forest" ["melidre"; "meki"]
   noun "memi" "wood (substance)" "wood" ["meki"]
   noun "memipe" "fragrant, good smelling, sweet" "fragrant" []
   noun "memome" "yesterday" "yesterday" ["meveme"; "kumome"]
   noun "merate" "first" "first" ["mira"] "short for \"elta tol mira\""
   noun "merepa" "warm, hot, cozy" "warm" [] "Refers to a comfortably warm temperature"
   noun "merke" "hour" "hour" []
   noun "merome" "collection of memories" "memories" ["meveme"] "Refers to the entire collection of memories that a person holds"
   noun "merope" "piece of memory" "memory" ["merome"] "Refers to a single remembered event"
   noun "mesote" "autumn, fall" "autumn" []
   noun "meta" "space, area" "area" []
   noun "meveki" "legacy" "legacy" ["meveme"]
   noun "meveme" "past" "past" ["meves"]
   noun "mika" "day (entire)" "day" [] "Refers to the twenty-four-hour period"
   noun "minaka" "daytime" "daytime" [] "Refers to the period between dawn and dusk"
   noun "mine" "subclause marker indicating the first argument as the head" "argument-1_of" []
   noun "morgome" "tomorrow" "tomorrow" []
   noun "moromi" "ancestors, ancestry" "ancestry" []
   noun "moropa" "rope" "rope" []
   noun "mumoka" "smooth, even" "smooth" []
   noun "nebuke" "dirty" "dirty" [] "Does not have to be covered in dirt, but anything that is undesirable"
   noun "nelelte" "year" "year" []
   noun "nelite" "season" "season" []
   noun "nelpe" "basket" "basket" []
   noun "nemite" "person who has lost a loved one" "love-lost person" [] "Specifically refers to a person whose love with a siginificant other (miradre); cannot be used like the term \"widow\""
   noun "neriti" "cool" "cool" [] "Refers to temperatures between 0°C and 10°C"
   noun "nolote" "bad, disagreeable, not likeable" "bad" []
   noun "nonte" "table, desk" "table" []
   noun "norite" "lion" "lion" []
   noun "numope" "bored" "bored" []
   noun "olape" "old, already familiar" "old" ["oliti"] "Refers to expressions like \"old news\" or \"old trick\""
   noun "oliti" "old, existed for a long time" "old" [] "Can refer to both objects and humans"
   noun "oluki" "old, near the end of lifespan" "old" ["oliti"] "Can refer to both objects and humans"
   noun "omota" "silent" "silent" [] "Refers to sound pressure levels below 30 dB"
   noun "pemete" "heavy" "heavy" ["pemipe"] "Refers to an object whose weight makes it difficult to handle"
   noun "pemipe" "heavy, heavyweight" "heavy" [] "Refers to an object whose weight is above what is expected"
   noun "pinuni" "medicine, drug" "medicine" ["pinut"]
   noun "piveke" "sour" "sour" []
   noun "podake" "dry" "dry" [] "Refers to an absence of moisture"
   noun "pomupa" "valley" "temitaa" []
   noun "ponaka" "lonely, alone" "alone" ["pona"]
   noun "popiki" "ugly" "ugly" []
   noun "poski" "fire" "fire" []
   noun "potike" "strong, mighty, powerful, forceful" "strong" []
   noun "prenta" "weight, heavy object" "weight" []
   noun "preta" "weighing scale" "scale" ["pregre"]
   noun "prete" "that one" "that" []
   noun "pretiki" "annoyingly loud" "loud" [] "Refers to loudness that causes discomfort"
   noun "pulte" "wall" "wall" []
   noun "raluta" "soft, malleable" "soft" []
   noun "relite" "evening" "evening" ["renel"; "relite"]
   noun "remika" "morning" "morning" ["renel"; "mika"]
   noun "remiti" "fish" "fish" []
   noun "renepe" "clean" "clean" [] "Refers to physical cleaniness; for figurative cleaniness, use \"lemid\" (pure)"
   noun "renoka" "early in the day" "early" []
   noun "repete" "scissors" "scissors" []
   noun "revita" "dream" "dream" [] "Refers to visions seen while sleeping"
   noun "rima" "moon (of Earth)" "moon" []
   noun "rimata" "moon (natural satellite)" "rimaa" []
   noun "rimpe" "month" "month" ["rima"]
   noun "rinome" "winter" "winter" ["rima"]
   noun "risme" "smoke" "smoke" []
   noun "ritma" "ash" "ash" [] "Specifically refers to the residue of burning"
   noun "romoka" "eerily quiet" "quiet" [] "Refers to unexpected quietness that causes anxiety"
   noun "rone" "here" "here" []
   noun "rote" "plain, field, open area" "field" []
   noun "rotopi" "illness, sickness, disease" "illness" []
   noun "runata" "dream, wish, ideal, goal" "goal" [] "Refers to a hypothetical reality that one wishes to bring to reality"
   noun "seliti" "animal" "animal" [] "Refers to the Animalia kingdom, thus including humans"
   noun "sempa" "week" "week" []
   noun "serepi" "good, likeable, agreeable" "good" ["seret"]
   noun "seskake" "solid" "solid" [] "Refers to the solid state of matter"
   noun "seskoma" "snow (substance)" "snow" [] "Refers to the snow itself, as opposed to the weather"
   noun "seskuna" "ice" "ice" ["seskake"; "kuna"]
   noun "sibepe" "hasty, hurried" "hasty" ["sibepe"]
   noun "sirita" "fast, rapid, quick" "fast" []
   noun "soki" "knife, blade" "knife" []
   noun "soponi" "pain" "pain" ["soki"; "poski"]
   noun "soroke" "slow" "slow" []
   noun "supe" "wrong" "wrong" ["vita"] "antonym of vid"
   noun "tate" "adult" "adult" ["tote"]
   noun "tatrete" "person" "person" [] "May refer to both adults and children"
   noun "temita" "mountain, hill" "mountain" []
   noun "teti" "small, little" "teti" []
   noun "tilte" "axe" "axe" []
   noun "tireka" "uncomfortably hot" "hot" [] "Subjectively defined; refers to a temperature that causes discomfort"
   noun "tosete" "hammer" "hammer" []
   noun "tote" "child" "child" []
   noun "trena" "stone (substance)" "stone" []
   noun "trenata" "statue" "statue" ["trena"]
   noun "treta" "rock" "rock" ["trena"]
   noun "tretete" "pleasantly loud" "loud" [] "Refers to loudness that is pleasant"
   noun "veneme" "spring" "spring" []
   noun "vilipi" "broom" "broom" ["vilme"]
   noun "vilme" "dust" "dust" [] "Refers to any fine-grained particles, including ash"
   noun "vita" "correct, right" "correct" [] "Used to describe something that conforms to a standard"
   noun "voline" "midnight, dark night" "midnight" ["vogre"; "lite"] "Refers to the time of the day when dusk and dawn are equidistant; to refer to 00:00, use \"trigre mika\" (beginning of day) instead"
   noun "volune" "solar noon" "noon" ["vogre"; "luna"] "Refers to the time of the day when the sun is at the zenith; to refer to 12:00, use \"vogro mika\" (middle of the day) instead"
   noun "vome" "soil" "soil" ["vosma"]
   noun "vosma" "earth, ground" "earth" [] "Refers to the ground, not the planet"
   noun "vosmi" "floor" "floor" ["vosma"] "Refers to any kind of indoor ground, not just wooden floor"
   noun "vosnata" "bay, gulf" "bay" ["vosma"; "kunata"]
   noun "vosrima" "fog,mist" "fog" ["vosma"; "lurika"]
   noun "amegre" "temperature of" "temperature_of" ["ameme"]
   noun "bedre" "hand of" "hand_of" ["besegre"]
   noun "besedre" "relative of" "relative" [] "Refers to anyone in the family who does not have another more specific kinship term"
   noun "besegre" "tool for..." "tool" [] "Refers to a tool for performing an action"
   noun "bevidre" "voice of" "voice" ["buvidre"]
   noun "bimigre" "anger, wrath, rage of" "anger" ["bimiti"]
   noun "bodogre" "beard of, mustache of" "beard_of" ["bomodre"; "dolidre"]
   noun "bodre" "father of" "father" []
   noun "bomodre" "chin of" "chin_of" []
   noun "bretodre" "son of" "son" []
   noun "buridre" "tongue of" "tongue_of" ["buvidre"] "Refers to the organ, not languages"
   noun "buvidre" "mouth of" "mouth" []
   noun "dedre" "moment of" "moment" [] "Used to denote \"when ...\" or \"at the moment when ...\""
   noun "delegre" "mood, emontional state of" "mood" ["demepa"; "leveka"]
   noun "delodre" "back of" "back_of" []
   noun "dolidre" "hair of" "hair_of" [] "Refers to any body hair"
   noun "dunagre" "age" "age" ["duna"] "Refers to the duration for which something has existed"
   noun "edre" "face of" "face" []
   noun "emodre" "worry, concern of" "worry" ["emonet"] "The associated word is the one having the worry"
   noun "eradre" "mistake, error made by" "mistake" []
   noun "gedre" "mother of" "mother" []
   noun "gelidre" "(daily) life of" "life_of" ["gelume"; "melidre"]
   noun "ginedre" "jaw of" "jaw_of" []
   noun "gladre" "arm of" "arm_of" [] "Refers to the limb"
   noun "glodre" "shoulder of" "shoulder_of" ["gladre"]
   noun "gredre" "leg of" "leg_of" []
   noun "gremegre" "soul, spirit of" "soul" ["grema"]
   noun "gresigre" "roof of" "roof_of" [] "gremu"
   noun "gritodre" "daughter of" "daughter" []
   noun "idogre" "poison to..." "poison" []
   noun "kanedre" "wave of" "wave" []
   noun "kebedre" "head of (body)" "head_of" [] "Cannot be used figuratively"
   noun "kemedre" "neck of" "neck_of" ["kebedre"]
   noun "kirigre" "bravery, courage of" "bravery" ["kirika"]
   noun "kregre" "color of, colour of" "colour_of" ["krete"] "Followed by an object with a characteristic colour to denote that colour"
   noun "kunidre" "breast of, chest of" "chest_of" []
   noun "leredre" "current of, flow of" "flow" ["leres"]
   noun "levegre" "grief, sorrow, sadness of" "sadness" ["levegre"]
   noun "lidre" "edge of" "edge" []
   noun "ligre" "name of" "name_of" []
   noun "liredre" "eye of" "eye" []
   noun "lukregre" "body of" "body_of" []
   noun "marodre" "aunt of, uncle of" "aunt/uncle" []
   noun "meledre" "stomach of" "stomach_of" []
   noun "melidre" "life (state) of" "life_of" ["melis"]
   noun "menedre" "belly of" "belly_of" []
   noun "mepogre" "finger of, toe of" "finger_of" []
   noun "metodre" "nose of" "nose_of" ["metot"]
   noun "metogre" "scent of, smell of" "scent_of" []
   noun "miradre" "significant other, soulmate" "soulmate" ["merat"] "Marriage does not change this usage of terms"
   noun "moridre" "brain of" "brain_of" []
   noun "morodre" "ancestor of" "ancestor" ["moromi"]
   noun "negre" "interior of" "interior" []
   noun "nelegre" "year of" "year" ["nelelte"] "Refers to a named, specific year"
   noun "nelvidre" "cheek of" "cheek_of" [] "Refers to facial cheek"
   noun "nepidre" "throat of" "throat_of" [] "Refers to the body part only"
   noun "nesegre" "elbow of, knee of, joint of" "joint_of" []
   noun "peledre" "descendant of" "descendant" ["morodre"]
   noun "petrogre" "taste of" "taste_of" ["petrot"]
   noun "pogre" "flesh of, meat of" "flesh_of" [] "Used only to describe animals and fruits"
   noun "porodre" "wound, painpoint of" "wound_of" [] "May be used figuratively, depending on its associated class"
   noun "pregre" "weight of" "weight_of" ["prenta"]
   noun "remigre" "human head hair of" "hair_of" []
   noun "retigre" "skin of" "skin_of" []
   noun "ridre" "vicinity of" "vicinity_of" [] "Denotes \"around <object>\""
   noun "rimogre" "month of" "month" ["rimpe"] "Followed by a number to denote a specific month"
   noun "segre" "desire for" "desire_for" ["set"]
   noun "semagre" "week of" "week" ["sempa"] "Refers to a named, specific week"
   noun "sinedre" "heart of" "heart_of" []
   noun "todre" "child (offspring) of" "child" ["tote"]
   noun "togedre" "tail of" "tail_of" ["tokigre"]
   noun "tokigre" "butt of, buttocks of" "butt_of" []
   noun "tregre" "end of" "end" ["trelot"] "Indicates the end of an action or a period (e.g. season or day)"
   noun "trigre" "start, beginning of" "beginning" ["trelit"]
   noun "venedre" "sibling of" "sibling" []
   noun "veredre" "ear of" "ear" []
   noun "vidre" "lip of" "lip_of" ["buvidre"]
   noun "vogodre" "tooth of" "tooth_of" [] "Usually refers to a person's complete set of teeth, unless specified using the singular inflection"
   noun "vogre" "midpoint of" "midpoint" []
   noun "vosedre" "foot of, paw of" "foot_of" [] "Refers to any body part that normally touches the ground"
   noun "votogre" "twin of" "twin_of" ["vora"; "tote"]
   noun "luvnaremi" "the clearing sky after rain" "clearing_sky" ["luvem"; "luna"; "gremi"]
   verb "balas" "laugh" "laugh" "{0} laughs" [] None None []
   verb "belep" "give, hand over" "give" "{0} gives {2} to {1}" ["besedre"] None None []
   verb "bemet" "feel, perceive" "feel" "{0} feels/perceives {1}" [] None None [None; Some "May be either a tangible object or an emotion"]
   verb "berit" "bite" "bite" "{0} bites {1}" ["buvlit"] None None []
   verb "beselet" "sweep" "sweep" "{0} sweeps {1}" [] None None [None; Some "May be any surface that can be swept using a broom"]
   verb "bet" "move" "move" "{0} moves {1}" [] (Some "Use the reflexive to indicate that {0} is moving") None []
   verb "bevat" "converse with, talk with" "converse" "{0} talks to {1}" ["bevidre"] None None []
   verb "bilesop" "carve" "carve" "{0} carves {1} out of {2}" ["bileka"] None None [None; Some "The shape or final form that is carved"; Some "The material for carving"]
   verb "binip" "weave, plait" "weave" "{0} weaves {1} out of {2}" [] None None [None; Some "The final product that is weaved"; Some "The material used for weaving"]
   verb "bores" "breathe" "breathe" "{0} breathes" ["borope"] None None []
   verb "borop" "blow on" "blow on" "{0} blows on {1} using {2}" [] None None [None; None; Some "The gas that is blown"]
   verb "bulit" "drink" "drink" "{0} drinks {1}" ["buvidre"] None None []
   verb "bup" "speak, say" "say" "{0} says {2} to {1}" ["buvidre"] None None []
   verb "buplit" "spit" "spit" "{0} spits out {1}" ["buvidre"] None None []
   verb "burit" "lick" "lick" "{0} licks {1}" ["buridre"] None None []
   verb "buvlit" "eat" "eat" "{0} eats {1}" ["buvidre"] None None []
   verb "delat" "equal to" "equal" "{0} is equal to {1}" [] None None []
   verb "delet" "arrive at" "arrive" "{0} arrives at {1}" [] None None [None; Some "Refers to a destination, not anything abstract (e.g. a conclusion)"]
   verb "delit" "tie together" "tie" "{0} ties {1} together" [] None None []
   verb "demis" "play, have fun" "play" "{0} is having fun" ["demepa"] None None []
   verb "dutup" "mold" "mold" "{0} molds {1} using {2}" [] None None [None; None; Some "The material used for molding"]
   verb "emalip" "return, come back" "return" "{0} returns {2} to {1}" [] (Some "Use the reflexive to denote that {0} is going back to {2}") None [None; None; Some "May be a place or a recipient"]
   verb "emelet" "have a fear for" "fear" "{0} fears {1}" ["emonet"] None None []
   verb "emonet" "worry about" "worry" "{0} is worried about {1}" [] None None []
   verb "enat" "enchain, enshackle" "enchain" "{0} enchains {1}" [] None None []
   verb "eprat" "touch" "touch" "{0} and {1} touch each other" [] None None []
   verb "epret" "touch" "touch" "{0} touches {1}" [] None None []
   verb "erat" "go to" "go" "{0} goes to {1}" [] None None []
   verb "geles" "live through everyday" "live" "{0} is living" ["gelidre"] None None []
   verb "gelit" "live, dwell at" "live_at" "{0} lives at {1}" ["gelidre"] None None []
   verb "glap" "carry" "carry" "{0} carries {1} to {2}" ["gladre"] None None []
   verb "gorit" "be proud of" "proud" "{0} is proud of {1}" [] None None []
   verb "grelet" "embrace" "embrace" "{0} embraces {1}" [] None None []
   verb "ilet" "faithful, loyal to" "faithful" "{0} is loyal to {1}" [] None None []
   verb "ires" "cough" "cough" "{0} coughs" [] None None []
   verb "kebot" "break (shatter)" "break" "{0} breaks {1}" [] None None []
   verb "kesis" "sneeze" "sneeze" "{0} sneezes" [] None None []
   verb "kirit" "dare, have the bravery to..." "dare" "{0} is dares to do {1}/{0} is brave enough for {1}" ["kirika"] None None [None; Some "For actions, use the gerund form"]
   verb "kitrot" "make, build, construct, create" "make" "{0} makes {1}" [] None None []
   verb "kivat" "cook" "cook" "{0} cooks {1}" [] None None []
   verb "krenit" "light up, illuminate" "illuminate" "{0} illuminates {1}" ["krene"] None None []
   verb "kunep" "pour" "pour" "{0} pours {2} into {1}" ["kuna"] None None []
   verb "kunerat" "swim" "swim" "{0} swims to {1}" ["kuna"; "erat"] None None []
   verb "larep" "show" "show" "{0} shows {2} to {1}" ["liret"] None None []
   verb "larit" "watch, stare at" "watch" "{0} stares at {1}" ["liret"] None None []
   verb "lebet" "harm, cause suffering to" "harm" "{0} harms {1}" ["leveka"] None None []
   verb "lemit" "pity, feel sorry for" "lemed" "{0} pities {1}" [] None None []
   verb "leres" "flow" "flow" "{0} is flowing" [] None None []
   verb "leris" "rest, take a break" "rest" "{0} is resting" [] None None []
   verb "lilip" "to give a name to" "name" "{0} gives the name of {2} to {1}" ["ligre"] None None []
   verb "liret" "look at" "look at" "{0} looks at {1}" ["liredre"] None None []
   verb "liseret" "witness" "witness" "{0} witnesses {1}" ["liret"] None None []
   verb "lisip" "cut" "cut" "{0} cuts {2} using {1}" [] (Some "Specialized words exist for cutting with scissors, knife, and axe") None []
   verb "litenes" "die" "die" "{0} dies" ["lite"] None None []
   verb "liveras" "sleep, especially through the night" "sleep" "{0} sleeps" [] None None []
   verb "lomot" "be sorry about, regret" "regret" "{0} regrets {1}" ["lemit"] None None []
   verb "luvem" "rain (weather condition)" "rain" "It is raining" [] None None []
   verb "meles" "live, be alive" "live" "{0} is alive" [] None None []
   verb "melis" "breathe" "melidro" "{0} is breathing" [] None None []
   verb "meranip" "sculpt" "sculpt" "{0} sculpts {1} out of {2}" [] None None [None; None; Some "the material used for sculpting"]
   verb "merat" "love romantically" "love" "{0} and {1} love each other" [] None None []
   verb "meret" "love, have feelings for" "love" "{0} has feelings for {1}" ["merat"] None None []
   verb "merit" "know, familiar with" "know" "{0} knows {1}" [] None None []
   verb "merot" "experience" "experience" "{0} experiences {1}" [] None None []
   verb "mesip" "become, transform into" "become" "{0} turns {1} into {2}" [] (Some "Use the reflexive to denote \"to become\", as in, {0} becomes {2}") None []
   verb "metot" "smell" "smell" "{0} smells {1}" ["metogre"] None None []
   verb "meves" "look back" "look back" "{0} is looking back" [] None None []
   verb "mirabat" "kiss on the lips" "kiss" "{0} and {1} kiss each other" ["merat"; "buvidre"] None None []
   verb "mirabut" "kiss" "kiss" "{0} kisses {1}" ["merat"; "buvidre"] None None []
   verb "morot" "spread out" "spread" "{0} spreads {1} out" [] None None []
   verb "narit" "run" "run" "{0} runs to {1}" [] None None [None; Some "The destination"]
   verb "neris" "cry, weep" "cry" "{0} is crying" [] None None []
   verb "nitrot" "read" "read" "{0} reads {1}" [] None None []
   verb "nolop" "blame" "blame" "{0} blames {1} for {2}" ["nolote"] None None [None; None; Some "The matter blamed for"]
   verb "petrot" "taste" "taste" "{0} tastes {1}" [] None None []
   verb "pinut" "heal, cure" "heal" "{0} heals {1}" [] None None []
   verb "polot" "hate" "hate" "{0} hates {1}" [] None None []
   verb "porip" "write" "write" "{0} writes {1} on {2}" [] None None [None; None; Some "The medium being written on"]
   verb "posip" "pull, draw" "pull" "{0} pulls {1} from {2}" ["tesip"] None None []
   verb "poskut" "burn" "burn" "{0} burns {1}" ["poski"] (Some "Use the reflexive to denote \"{0} is burning/on fire\"") None []
   verb "prelis" "be ready, idling, waiting" "ready" "{0} is ready" [] None None []
   verb "rebot" "cut (with scissors)" "cut" "{0} cuts {1} with scissors" ["repete"] None None []
   verb "relot" "remain at, stay at" "remain" "{0} stays at {1}" [] None None []
   verb "resip" "paint" "paint" "{0} paints {1} using {2}" [] None None [None; None; Some "The paint used for the painting"]
   verb "rilep" "wash" "wash" "{0} washes {1} in {2}" [] None None []
   verb "rilip" "bring" "bring" "{0} brings {2} to {1}" [] None None []
   verb "sebot" "break (split)" "break" "{0} breaks {1}" ["kebot"] None None []
   verb "senip" "rub, wipe" "rub" "{0} wipes {1} using {2}" [] None None []
   verb "seret" "like, be fond of" "like" "{0} likes {1}" [] None None []
   verb "seskom" "snow (weather condition)" "snow" "It is snowing" ["seskuna"] None None []
   verb "set" "want, desire, wish" "want" "{0} wants {1}" [] None None []
   verb "sibit" "hurry, rush" "hurry" "{0} rushes {1}" [] (Some "Use the reflexive to denote \"{0} is rushing/in a hurry\"") None []
   verb "silip" "shoot, fire, blast" "shoot" "{0} shoots/fires {1} towards {2}" [] None None []
   verb "sirit" "rip, tear" "rip" "{0} rips {1}" [] None None []
   verb "sokut" "cut (with knife)" "cut" "{0} cuts {1} with a knife" ["soki"] None None []
   verb "tenet" "fill, take up space, flood with" "fill" "{0} floods {1}" ["tenip"] None None []
   verb "tenip" "fill" "fill" "{0} fills {1} with {2}" [] None None [None; None; Some "The substance that fills up"]
   verb "teret" "cause" "cause" "{0} causes {1}" [] None None []
   verb "tesip" "press, push, compress" "push" "{0} pushes {1} against/towards {2}" [] None None []
   verb "tilit" "cut, chop (with axe)" "chop" "{0} chops {1} with an axe" ["tilte"] None None []
   verb "titolit" "kill" "kill" "{0} kills {1}" [] None None []
   verb "tomop" "postpone, delay" "postpone" "{0} postpones {1} until {2}" [] None None []
   verb "tot" "hit, strike, beat" "hit" "{0} hits {1}" [] None None []
   verb "trelit" "begin, start" "begin" "{0} starts {1}" [] (Some "Use the reflexive to denote \"{0} starts\"") None []
   verb "trelot" "finish, complete" "finish" "{0} finishes {1}" [] (Some "Use the reflexive to denote \"{0} ends\"") None []
   verb "trolot" "stop" "stop" "{0} stops {1}" [] None None []
   verb "veret" "listen to, hear" "hear" "{0} listens to {1}" ["veredre"] None None []
   verb "vilot" "bend" "bend" "{0} bends {1}" [] None None []
   verb "vomot" "wake up, awaken" "wake_up" "{0} wakes {1} up" [] (Some "Use the reflexive to denote \"{0} wakes up\"") None []
   verb "vosip" "bury" "bury" "{0} buries {1} into {2}" ["vosma"] None None []
   verb "vososit" "fold" "fold" "{0} folds {1}" [] None None []
   verb "vulot" "stretch" "stretch" "{0} stretches {1}" [] None None []
   modifier "bomol" "sometimes, occassionally" "sometimes" [Verb0; Verb1; Verb12; Verb123; Verb2; Verb23; Verb3; Verb13] [] [] "Used to modify verb infinitives to indicate a repeating action that happens sometimes"
   modifier "borol" "few, little" "few" [WordType.Noun; WordType.Noun] [] []
   modifier "dal" "at the time of, when" "at_time" [WordType.Noun; WordType.Noun; Verb0; Verb1; Verb12; Verb123; Verb2; Verb23; Verb3; Verb13] [WordType.Noun] []
   modifier "del" "of, beloning to" "of" [WordType.Noun] [WordType.Noun] [] "Refers to ownership; stronger than \"vol\", which is semantically vague about the relationship"
   modifier "evotol" "natural logarithm" "ln" [Digit] [Predicate] []
   modifier "kanel" "able to, can, capably, skillfully" "capably" [Verb1; Verb12; Verb123] [] [] "When modifying a hypothetical verb, it corresponds to \"can\" or \"be able to\""
   modifier "kerel" "and (connecting clauses)" "and" [Verb0; Verb1; Verb12; Verb123; Verb2; Verb23; Verb3; Verb13] [Predicate] []
   modifier "konal" "another, other" "another" [WordType.Noun] [] []
   modifier "kumol" "today" "today" [WordType.Noun; WordType.Noun; Verb0; Verb1; Verb12; Verb123; Verb2; Verb23; Verb3; Verb13] [] ["kumome"] "Stands for \"dal kumome\""
   modifier "mebel" "square root of" "sqrt" [Digit] [Predicate] []
   modifier "mel" "in, within (abstract)" "in" [WordType.Noun; WordType.Noun; Verb0; Verb1; Verb12; Verb123; Verb2; Verb23; Verb3; Verb13] [WordType.Noun] [] "Used to describe being within a timeframe or environment, such as \"in the night\", \"in a week\""
   modifier "meral" "but, however" "but" [Verb0; Verb1; Verb12; Verb123; Verb2; Verb23; Verb3; Verb13] [Predicate] []
   modifier "mogal" "tomorrow" "tomorrow" [WordType.Noun; WordType.Noun; Verb0; Verb1; Verb12; Verb123; Verb2; Verb23; Verb3; Verb13] [] ["morgome"] "Stands for \"dal morgome\""
   modifier "nal" "with the name of" "named" [WordType.Noun; WordType.Noun] [Predicate] [] "The following word is the name of the modified object"
   modifier "nel" "in, inside" "in" [WordType.Noun; WordType.Noun; Verb0; Verb1; Verb12; Verb123; Verb2; Verb23; Verb3; Verb13] [WordType.Noun] [] "Used to denote the interior of a physical space"
   modifier "nil" "(modifier sealer)" "-" [WordType.Noun; WordType.Noun; Verb0; Verb1; Verb12; Verb123; Verb2; Verb23; Verb3; Verb13] [] [] "Prevents this word from accepting additional modifiers"
   modifier "nival" "other than, not" "not" [WordType.Noun; WordType.Noun; Verb0; Verb1; Verb12; Verb123; Verb2; Verb23; Verb3; Verb13] [] [] "Used to mean \"something other than\", which is sometimes indicated with negation in natural languages"
   modifier "nivoral" "never again" "never_again" [Verb0; Verb1; Verb12; Verb123; Verb2; Verb23; Verb3; Verb13] [] ["voral"]
   modifier "nomal" "always, regularly" "always" [Verb0; Verb1; Verb12; Verb123; Verb2; Verb23; Verb3; Verb13] [] [] "When modifying an infinitive, indicates that the action occurs regularly; when modifying an ongoing action (either progressive or also having \"tenil\" attached to it), indicates that the action will not stop"
   modifier "nomil" "in order to" "in order to" [Verb0; Verb1; Verb12; Verb123; Verb2; Verb23; Verb3; Verb13] [Predicate] [] "Modifies a verb to indicate that it's done in order to perform another action"
   modifier "petal" "multiply, multiplied by, times" "times" [Digit] [Predicate] []
   modifier "ponel" "next to, by, with" "with" [WordType.Noun; WordType.Noun; Verb0; Verb1; Verb12; Verb123; Verb2; Verb23; Verb3; Verb13] [WordType.Noun] []
   modifier "regel" "soon" "soon" [Verb0; Verb1; Verb12; Verb123; Verb2; Verb23; Verb3; Verb13] [] []
   modifier "renel" "early" "early" [Verb0; Verb1; Verb12; Verb123; Verb2; Verb23; Verb3; Verb13] [] [] "Modifies a stopped verb to indicate that it finished before the expected time"
   modifier "sel" "quantity/count specifier" "count" [WordType.Noun] [Predicate] [] "Followed by the number of instances of a countable noun"
   modifier "senal" "minus" "minus" [Digit] [Predicate] []
   modifier "sivil" "obligatorily, have to, must" "have_to" [Verb0; Verb1; Verb12; Verb123; Verb2; Verb23; Verb3; Verb13] [] [] "Modifies a hypothetical verb to indicate the obligation of doing it"
   modifier "sonal" "only" "only" [WordType.Noun; WordType.Noun; Verb0; Verb1; Verb12; Verb123; Verb2; Verb23; Verb3; Verb13] [] []
   modifier "sonol" "without, lacking" "without" [WordType.Noun; WordType.Noun] [WordType.Noun] [] "Used to modify an object that lacks an association, either through ownership or characteristic, with the following object"
   modifier "tikal" "plus" "plus" [Digit] [Predicate] []
   modifier "tikanel" "summation" "summation" [Digit] [Predicate; Predicate; Predicate] ["tikal"]
   modifier "tokol" "late, near the end of a period of time" "late" [Verb0; Verb1; Verb12; Verb123; Verb2; Verb23; Verb3; Verb13] [] []
   modifier "tomol" "late" "late" [] [] [] "Refers to an action occuring after the expected time"
   modifier "vetel" "exponentiation, to the power of" "exponent" [Digit] [Predicate] []
   modifier "visal" "divided by" "divided_by" [Digit] [Predicate] []
   modifier "vol" "of, pertaining to" "of" [WordType.Noun; WordType.Noun; Verb0; Verb1; Verb12; Verb123; Verb2; Verb23; Verb3; Verb13] [WordType.Noun] [] "Links two objects without explicitly stating the nature of the relationship, which is left to the context to decide"
   modifier "voral" "again" "again" [Verb0; Verb1; Verb12; Verb123; Verb2; Verb23; Verb3; Verb13] [] ["vora"]
   modifier "votel" "squared (multiplied by itself)" "squared" [Digit] [] ["vora"; "mebel"]
   modifier "votol" "logarithm in the given base" "log" [Digit] [Predicate] []
   word "di" "decimal point" "." []
   word "gi" "9, nine (non-terminal)" "9" []
   word "gina" "9, nine (terminal)" "9" []
   word "ke" "8, eight (non-terminal)" "8" []
   word "kera" "8, eight (terminal)" "8" []
   word "kle" "million (non-terminal)" "million" [] "Represents 1 000 000 at the start of the sequence digits; 000 000 elsewhere"
   word "klera" "million (non-terminal)" "million" [] "Represents 1 000 000 by itself; 000 000 elsewhere"
   word "li" "6, six (non-terminal)" "6" []
   word "lira" "6, six (terminal)" "6" []
   word "mi" "0, significant zero (non-terminal)" "0" []
   word "mira" "0, significant zero (terminal)" "0" []
   word "no" "3, three (non-terminal)" "3" []
   word "nona" "3, three (terminal)" "3" []
   word "plo" "100, hundred (non-terminal)" "hundred" [] "Represents 100 at the start of the sequence digits; 00 elsewhere"
   word "plora" "100, hundred (non-terminal)" "hundred" [] "Represents 100 by itself; 00 elsewhere"
   word "po" "1, one (non-terminal)" "1" []
   word "pona" "1, one (terminal)" "1" []
   word "si" "5, five (non-terminal)" "5" []
   word "sina" "5, five (terminal)" "5" []
   word "so" "7, seven (non-terminal)" "7" []
   word "sona" "7, seven (terminal)" "7" []
   word "te" "4, four (non-terminal)" "4" []
   word "tera" "4, four (terminal)" "4" []
   word "tri" "1000, thousand (non-terminal)" "thousand" [] "Represents 1000 at the start of the sequence digits; 000 elsewhere"
   word "trira" "1000, thousand (terminal)" "thousand" [] "Represents 1000 by itself; 000 elsewhere"
   word "vo" "2, two (non-terminal)" "2" []
   word "vora" "2, two (terminal)" "2" []
   word "hal" "everything, all" "everything" ["avilma"] "Functionally identical to \"avilma\""
   word "hel" "something, someone" "something" ["avelme"] "Functionally identical to \"avelme\""
   word "hem" "I" "I" ["emika"] "Functionally identical to \"emikasi\""
   word "hes" "you (singular)" "you" ["esika"] "Functionally identical to \"esikasi\""
   word "het" "he, she, it; third-person singular pronoun" "3PS" ["etika"] "Functionally identical to \"etikasi\""
   word "hime" "We" "We" ["emika"] "Functionally identical to \"emikave\""
   word "hise" "you (plural)" "you" ["esika"] "Functionally identical to \"esikave\""
   word "hite" "they" "3PP" ["etika"] "Functionally identical to \"each other\""
}