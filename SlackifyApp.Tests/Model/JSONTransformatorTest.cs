using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlackifyApp;
using SlackifyApp.Model;

namespace SlackifyApp.Tests.Model
{
    [TestClass]
    public class JSONTransformatorTest
    {
        [TestMethod]
        public void cuando_transformo_un_JSON_con_un_transformado_configurado_con_un_XPATH__queda_el_string_de_ese_path()
        {
            JSONTransformator transformator = new JSONTransformator("one_ring");
            string json = @"{
                                'one_ring': 'to_rules_them_all'
                            }";

            String result = transformator.Transform(json);

            Assert.AreEqual("to_rules_them_all", result);
        }


        [TestMethod]
        public void cuando_transformo_un_JSON_con_un_transformado_configurado_con_mas_de_un_nivel_con_un_XPATH__queda_el_string_de_ese_path()
        {
            JSONTransformator transformator = new JSONTransformator("one_ring.attracts");
            string json = @"{
                                'one_ring': {
                                    'rules_them_all': true,
                                    'attracts': 'them_all'
                                }
                            }";

            String result = transformator.Transform(json);

            Assert.AreEqual("them_all", result);
        }


        [TestMethod]
        public void cuando_transformo_un_JSON_con_una__array_con_XPATH__queda_el_string_de_ese_path()
        {
            JSONTransformator transformator = new JSONTransformator("hobbits[1]");
            string json = @"{
                                'hobbits': [ 
                                    'Frodo', 'Sam'
                                ]
                            }";

            String result = transformator.Transform(json);

            Assert.AreEqual("Sam", result);
        }
    }
}
