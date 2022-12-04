using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStatsFuzzy2Controller.FuzzyModel;

namespace GameStatsFuzzy2Controller
{
    public static class Fuzzy2Model
    {
        public static LV2[] InputLVs { get => _inputLVs; }
        public static LV2 OutputLV { get => _outputLV; }
        public static Rule2[] RuleBase { get => _ruleBase; }

        private static LV2[] _inputLVs;
        private static LV2 _outputLV;
        private static Rule2[] _ruleBase;

        public static void SetUpModel()
        {
            _inputLVs = new LV2[]{
                new LV2( "Focused Attention", "When I was playing the game, I lost track of the world around me", new Term2[]
                {
                    new Term2("Strongly disagree", upperBound: new Term2.TermCreationInfoStruct(new float[]{ 0,0,.5f,2.5f }),
                                                   lowerBound: new Term2.TermCreationInfoStruct(new float[]{ 0,0,.5f,1.5f })),

                    new Term2("Disagree", upperBound: new Term2.TermCreationInfoStruct(new float[]{ 1,3,4,4.5f }),
                                          lowerBound: new Term2.TermCreationInfoStruct(new float[]{ 2,3,3.5f,4 }, height: .6f)),

                    new Term2("Neither agree nor disagree", upperBound: new Term2.TermCreationInfoStruct(new float[]{ 3,4.5f,5.5f,7 }),
                                                            lowerBound: new Term2.TermCreationInfoStruct(new float[]{ 4,4.5f,5.5f,6 })),

                    new Term2("Agree", upperBound: new Term2.TermCreationInfoStruct(new float[]{ 5.5f,7,8,10 }),
                                       lowerBound: new Term2.TermCreationInfoStruct(new float[]{ 6.5f,7f,8f, 8.5f }, height: .5f)),

                    new Term2("Strongly agree", upperBound: new Term2.TermCreationInfoStruct(new float[]{ 9,9.5f,10,10 }),
                                                lowerBound: new Term2.TermCreationInfoStruct(new float[]{ 9.5f,10,10,10 })),
                }),

                new LV2( "Perceived Usability", "I felt discouraged while playing", new Term2[]
                {
                    new Term2("Strongly disagree", upperBound: new Term2.TermCreationInfoStruct(new float[]{ 8,10,10,10 }),
                                                   lowerBound: new Term2.TermCreationInfoStruct(new float[]{ 9,10,10,10 })),

                    new Term2("Disagree", upperBound: new Term2.TermCreationInfoStruct(new float[]{ 5.5f,7,9,10 }),
                                          lowerBound: new Term2.TermCreationInfoStruct(new float[]{ 6.5f,7,8,9 }, height: .8f)),

                    new Term2("Neither agree nor disagree", upperBound: new Term2.TermCreationInfoStruct(new float[]{ 4,5,6,6.5f }),
                                                            lowerBound: new Term2.TermCreationInfoStruct(new float[]{ 4.5f,5,5.5f,6 }, height: .6f)),

                    new Term2("Agree", upperBound: new Term2.TermCreationInfoStruct(new float[]{ 1,2.5f,4,4.5f }),
                                       lowerBound: new Term2.TermCreationInfoStruct(new float[]{ 2,2.5f,3.5f,4 }, height: .5f)),

                    new Term2("Strongly agree", upperBound: new Term2.TermCreationInfoStruct(new float[]{ 0,0,1,2.5f }),
                                                lowerBound: new Term2.TermCreationInfoStruct(new float[]{ 0,0,1,2 }))
                }),

                new LV2( "Aesthetics", "I liked the graphics and textures used in the game", new Term2[]
                {
                    new Term2("Strongly disagree", upperBound: new Term2.TermCreationInfoStruct(new float[]{ 0,0,1,2 }),
                                                   lowerBound: new Term2.TermCreationInfoStruct(new float[]{ 0,0,1,1.5f })),

                    new Term2("Disagree", upperBound: new Term2.TermCreationInfoStruct(new float[]{ 1,2,3.5f,4.5f }),
                                          lowerBound: new Term2.TermCreationInfoStruct(new float[]{ 2,2.5f,3,4 }, height: .7f)),

                    new Term2("Neither agree nor disagree", upperBound: new Term2.TermCreationInfoStruct(new float[]{ 3.5f,5,6,7 }),
                                                            lowerBound: new Term2.TermCreationInfoStruct(new float[]{ 4,5,5.5f,6 }, height: .9f)),

                    new Term2("Agree", upperBound: new Term2.TermCreationInfoStruct(new float[]{ 6,7,9,10 }),
                                       lowerBound: new Term2.TermCreationInfoStruct(new float[]{ 7,7.5f,8.5f,9.5f }, height: .5f)),

                    new Term2("Strongly agree", upperBound: new Term2.TermCreationInfoStruct(new float[]{ 8,10,10,10 }),
                                                lowerBound: new Term2.TermCreationInfoStruct(new float[]{ 9,10,10,10 })),
                }),

                new LV2( "Satisfaction", "The content of the game piqued my curiosity", new Term2[]
                {
                    new Term2("Strongly disagree", upperBound: new Term2.TermCreationInfoStruct(new float[]{ 0,0,2,3 }),
                                                   lowerBound: new Term2.TermCreationInfoStruct(new float[]{ 0,0,1,2 })),

                    new Term2("Disagree", upperBound: new Term2.TermCreationInfoStruct(new float[]{ 1.5f,3,4,5}),
                                          lowerBound: new Term2.TermCreationInfoStruct(new float[]{ 2,3,4,4.5f }, height: .6f)),

                    new Term2("Neither agree nor disagree", upperBound: new Term2.TermCreationInfoStruct(new float[]{ 3.5f,5,6,7 }),
                                                            lowerBound: new Term2.TermCreationInfoStruct(new float[]{ 4,5,6,6.5f }, height: .4f)),

                    new Term2("Agree", upperBound: new Term2.TermCreationInfoStruct(new float[]{ 6,7,8.5f,9 }),
                                       lowerBound: new Term2.TermCreationInfoStruct(new float[]{ 7,7.5f,8,8.5f }, height: .7f)),

                    new Term2("Strongly agree", upperBound: new Term2.TermCreationInfoStruct(new float[]{ 8,9.5f,10,10 }),
                                                lowerBound: new Term2.TermCreationInfoStruct(new float[]{ 9,9.5f,10,10 })),
                })
            };

            _outputLV = new LV2("Interest", "Interest", new Term2[]
                {
                    new Term2("None to very little", upperBound: new Term2.TermCreationInfoStruct(new float[]{ 0,0,0.5f,1.5f }),
                                                     lowerBound: new Term2.TermCreationInfoStruct(new float[]{ 0,0,0.5f,1 })),

                    new Term2("Very low", upperBound: new Term2.TermCreationInfoStruct(new float[]{ 0.5f,2,2.5f,3 }),
                                          lowerBound: new Term2.TermCreationInfoStruct(new float[]{ 1,2,2.5f,3 }, height: .6f)),

                    new Term2("Low", upperBound: new Term2.TermCreationInfoStruct(new float[]{ 2,3,3.5f,4.5f }),
                                     lowerBound: new Term2.TermCreationInfoStruct(new float[]{ 2.5f,3,3.5f,4 }, height: .7f)),

                    new Term2("Medium", upperBound: new Term2.TermCreationInfoStruct(new float[]{ 4,5,5.5f,6 }),
                                        lowerBound: new Term2.TermCreationInfoStruct(new float[]{ 4.5f,5,5.5f,6 }, height: .6f)),

                    new Term2("Above medium", upperBound: new Term2.TermCreationInfoStruct(new float[]{ 5.5f,6.5f,7,8 }),
                                              lowerBound: new Term2.TermCreationInfoStruct(new float[]{ 6,6.5f,7,7.5f }, height: .5f)),

                    new Term2("High", upperBound: new Term2.TermCreationInfoStruct(new float[]{ 7.5f,8.5f,9,10 }),
                                      lowerBound: new Term2.TermCreationInfoStruct(new float[]{ 8,8.5f,9,9.5f }, height: .5f)),

                    new Term2("Extremely high", upperBound: new Term2.TermCreationInfoStruct(new float[]{ 9,10,10,10 }),
                                                lowerBound: new Term2.TermCreationInfoStruct(new float[]{ 9.5f,10,10,10 }))
                }
            );

            _ruleBase = Rule2.GenerateRuleBase(_inputLVs, _outputLV);
        }
    }
}
