﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.34209
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Développer une story")]
    public partial class DevelopperUneStoryFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Story.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("fr-FR"), "Développer une story", "", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Quand un développeur travaille sur une story, ca charge de travaille diminue")]
        public virtual void QuandUnDeveloppeurTravailleSurUneStoryCaChargeDeTravailleDiminue()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Quand un développeur travaille sur une story, ca charge de travaille diminue", ((string[])(null)));
#line 3
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Titre",
                        "Charge"});
            table1.AddRow(new string[] {
                        "Souscrire un contrat",
                        "2"});
#line 5
 testRunner.Given("le projet \'Crocto\' avec les stories suivantes", ((string)(null)), table1, "Etant donné ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Nom"});
            table2.AddRow(new string[] {
                        "Alice"});
#line 9
 testRunner.Given("l\'équipe \'A-team\' est constituée de", ((string)(null)), table2, "Soit ");
#line 13
 testRunner.And("l\'équipe \'A-team\' travaille sur le projet \'Crocto\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 15
 testRunner.Given("le daily pour le projet \'Crocto\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Etant donné ");
#line 16
 testRunner.Given("que \'Alice\' travaille sur \'Souscrire un contrat\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Etant donné ");
#line 17
 testRunner.When("la journée se termine", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Titre",
                        "Charge"});
            table3.AddRow(new string[] {
                        "Souscrire un contrat",
                        "1"});
#line 18
 testRunner.Then("les stories du projet \'Crocto\' sont dans l\'état suivant", ((string)(null)), table3, "Alors ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Une story est terminée lorsque sa charge atteint 0")]
        public virtual void UneStoryEstTermineeLorsqueSaChargeAtteint0()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Une story est terminée lorsque sa charge atteint 0", ((string[])(null)));
#line 22
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Titre",
                        "Charge"});
            table4.AddRow(new string[] {
                        "Souscrire un contrat",
                        "1"});
            table4.AddRow(new string[] {
                        "Déclarer un sinistre",
                        "2"});
#line 24
 testRunner.Given("le projet \'Crocto\' avec les stories suivantes", ((string)(null)), table4, "Etant donné ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Nom"});
            table5.AddRow(new string[] {
                        "Alice"});
#line 28
 testRunner.Given("l\'équipe \'A-team\' est constituée de", ((string)(null)), table5, "Soit ");
#line 32
 testRunner.Given("que \'Alice\' travaille sur \'Souscrire un contrat\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Etant donné ");
#line 33
 testRunner.When("la journée se termine", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Titre",
                        "Charge"});
            table6.AddRow(new string[] {
                        "Déclarer un sinistre",
                        "2"});
#line 34
 testRunner.Then("les stories du projet \'Crocto\' sont dans l\'état suivant", ((string)(null)), table6, "Alors ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
