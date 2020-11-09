﻿namespace MySolution.Module.Controllers
{
    partial class FindBySubjectController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.FindBySubjectAction = new DevExpress.ExpressApp.Actions.ParametrizedAction(this.components);
            // 
            // FindBySubjectAction
            // 
            this.FindBySubjectAction.Caption = "Find By Subject Action";
            this.FindBySubjectAction.ConfirmationMessage = null;
            this.FindBySubjectAction.Id = "FindBySubjectAction";
            this.FindBySubjectAction.NullValuePrompt = null;
            this.FindBySubjectAction.ShortCaption = null;
            this.FindBySubjectAction.TargetObjectType = typeof(MySolution.Module.BusinessObjects.DemoTask);
            this.FindBySubjectAction.TargetViewNesting = DevExpress.ExpressApp.Nesting.Root;
            this.FindBySubjectAction.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.FindBySubjectAction.ToolTip = null;
            this.FindBySubjectAction.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.FindBySubjectAction.Execute += new DevExpress.ExpressApp.Actions.ParametrizedActionExecuteEventHandler(this.FindBySubjectAction_Execute);
            // 
            // FindBySubjectController
            // 
            this.Actions.Add(this.FindBySubjectAction);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.ParametrizedAction FindBySubjectAction;
    }
}
