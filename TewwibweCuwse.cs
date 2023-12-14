using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Roost;
using SecretHistories.Entities;
using SecretHistories.Fucine.DataImport;

    public class ATewwibweCuwse
    {
        public static void Initialise()
        {
            NoonUtility.Log(Uwuify("A Terrible Curse has befallen this game. Prepare yourself."));
            Machine.AddImportMolding<Element>(UwuAction);
            Machine.AddImportMolding<Achievement>(UwuAction);
            Machine.AddImportMolding<Ending>(UwuAction);
            Machine.AddImportMolding<Legacy>(UwuAction);
            Machine.AddImportMolding<Recipe>(UwuAction);
            Machine.AddImportMolding<Verb>(UwuAction);
            Machine.AddImportMolding<Portal>(UwuAction);
        }
        public static Action<EntityData> UwuAction = data =>
        {
            if (data.ContainsKey("description"))
            {
                data["description"] = Uwuify(data["description"].ToString());
            }
            if(data.ContainsKey("startdescription"))
            {
                data["startdescription"] = Uwuify(data["startdescription"].ToString());
            }
            if(data.ContainsKey("label"))
            {
                data["label"] = Uwuify(data["label"].ToString());
            }
            if(data.ContainsKey("descriptionunlocked"))
            {
                data["descriptionunlocked"] = Uwuify(data["descriptionunlocked"].ToString());
            }
            if(data.ContainsKey("xexts"))
            {
                object xexts = data["xexts"];
                
                data["descriptionunlocked"] = Uwuify(data["descriptionunlocked"].ToString());
            }
            
        };

        public static string UwuifyRefinements(string input)
        {
            var inputSpl=input.Split('@');
            for (int i = 0; i < inputSpl.Length; i++)
            {
                if (i % 2 == 0)
                {
                    //it's plain text, but could have tags
                    inputSpl[i]=UwuifyTags(inputSpl[i]);
                }
                else
                {
                    // it's a refinement block
                    var spli=Regex.Split(inputSpl[i], @"(?<=[#|])");
                    for (int j = 0; j < spli.Length; j++)
                    {
                        //on evens, do nothing. on odds, transform...?
                        if(j%2==0) 
                            spli[j]=UwuifyTags(spli[j]);
                        
                    }
                    //rejoin it and move on to the next index
                    inputSpl[i]=String.Join("",spli);
                }
            }
            return String.Join("@",inputSpl);
        }
        public static string UwuifyTags(string input)
        {
            var splinput = Regex.Split(input, @"(?<=[<>])");
            
            for (int i = 0; i < splinput.Length; i++)
            {
                if(i%2==0)
                    splinput[i]=UwuifyTransform(splinput[i]);
            }
            return String.Join("",splinput);

        }

        public static string UwuifyTransform(string input)
        {
            input=" "+input;
            
                input = input.ToLower();
                input = input.Replace("small", "smol");
                input = input.Replace("cute", "kawaii");
                input = input.Replace("fluff", "floof");
                input = input.Replace("love", "luv");
                input = input.Replace("what", "nani");
                input = input.Replace("stupid", "baka");
                input = input.Replace("meow", "nya");
                input = input.Replace('l', 'w');
                input = input.Replace('r', 'w');
                input = input.Replace(" n", " ny");
                input = input.Replace("PWEVIOUSCHAWACTEWNAME".ToLower(), "PREVIOUSCHARACTERNAME");
                input = input.Replace("WAST_FOWWOWEW".ToLower(), "LAST_FOLLOWER");
                input = input.Replace("WAST_BOOK".ToLower(), "LAST_BOOK");
                input = input.Replace("WAST_DESIWE".ToLower(), "LAST_DESIRE"); 
            
            input = input.Substring(1);
           

            return input;
        }
            public static string Uwuify(string input)
        {
            // supposedly, this recipe is no longer broken
            // if (input.Contains("Our enemy is one Captain Welland"))
            // {
            //     return input; // this fuckin recipe is broken so we skip it entirely. 
            // }
            if (input.Contains("@"))
            {
                input = UwuifyRefinements(input);
            } else if (input.Contains("<"))
            {
                input=UwuifyTags(input);
                
        } else
            input=UwuifyTransform(input);
            
        return input;
        }
    }
