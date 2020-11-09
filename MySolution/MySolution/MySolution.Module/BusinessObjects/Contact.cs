using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace MySolution.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Contact : Person
    {
        public Contact(Session session) : base(session) { }
        private string webPageAddress;
        public string WebPageAddress
        {
            get { return webPageAddress; }
            set { SetPropertyValue(nameof(WebPageAddress), ref webPageAddress, value); }
        }
        private string nickName;
        public string NickName
        {
            get { return nickName; }
            set { SetPropertyValue(nameof(NickName), ref nickName, value); }
        }
        private string spouseName;
        public string SpouseName
        {
            get { return spouseName; }
            set { SetPropertyValue(nameof(SpouseName), ref spouseName, value); }
        }
        private TitleOfCourtesy titleOfCourtesy;
        public TitleOfCourtesy TitleOfCourtesy
        {
            get { return titleOfCourtesy; }
            set { SetPropertyValue(nameof(TitleOfCourtesy), ref titleOfCourtesy, value); }
        }
        private DateTime anniversary;
        public DateTime Anniversary
        {
            get { return anniversary; }
            set { SetPropertyValue(nameof(Anniversary), ref anniversary, value); }
        }
        private string notes;
        [Size(4096)]
        public string Notes
        {
            get { return notes; }
            set { SetPropertyValue(nameof(Notes), ref notes, value); }
        }

        private Department department;
        [Association("Department-Contacts", typeof(Department)), ImmediatePostData]
        public Department Department
        {
            get { return department; }
            set
            {
                SetPropertyValue(nameof(Department), ref department, value);
                if (!IsLoading)
                {
                    Position = null;
                    if (Manager != null && Manager.Department != value)
                    {
                        Manager = null;
                    }
                }
            }
        }
        private Position position;
        public Position Position
        {
            get { return position; }
            set { SetPropertyValue(nameof(Position), ref position, value); }
        }

        [Association("Contact-DemoTask")]
        public XPCollection<DemoTask> Tasks
        {
            get
            {
                return GetCollection<DemoTask>(nameof(Tasks));
            }
        }

        private Contact manager;
        [DataSourceProperty("Department.Contacts",DataSourcePropertyIsNullMode.SelectAll)]
        [DataSourceCriteria("Position.Title = 'Manager' AND Oid != '@This.Oid'")]
        public Contact Manager
        {
            get { return manager; }
            set { SetPropertyValue(nameof(Manager), ref manager, value); }
        }

    }
    public enum TitleOfCourtesy { Dr, Miss, Mr, Mrs, Ms };

    [DefaultClassOptions]
    [System.ComponentModel.DefaultProperty(nameof(Title))]
    public class Department : BaseObject
    {
        public Department(Session session) : base(session) { }
        private string title;
        public string Title
        {
            get { return title; }
            set { SetPropertyValue(nameof(Title), ref title, value); }
        }
        private string office;
        public string Office
        {
            get { return office; }
            set { SetPropertyValue(nameof(Office), ref office, value); }
        }

        [Association("Department-Contacts")]
        public XPCollection<Contact> Contacts
        {
            get
            {
                return GetCollection<Contact>(nameof(Contacts));
            }
        }

        [Association("Departments-Positions")]
        public XPCollection<Position> Positions
        {
            get { return GetCollection<Position>(nameof(Positions)); }
        }
    }
    [DefaultClassOptions]
    [System.ComponentModel.DefaultProperty(nameof(Title))]
    [System.ComponentModel.DisplayName("ポジション")]
    public class Position : BaseObject
    {
        public Position(Session session) : base(session) { }
        private string title;
        [RuleRequiredField(DefaultContexts.Save)]
        public string Title
        {
            get { return title; }
            set { SetPropertyValue(nameof(Title), ref title, value); }
        }

        [Association("Departments-Positions")]
        public XPCollection<Department> Departments
        {
            get { return GetCollection<Department>(nameof(Departments)); }
        }
    }

    [DefaultClassOptions]
    [ModelDefault("Caption", "Task")]
    public class DemoTask : Task
    {
        public DemoTask(Session session) : base(session) { }
        [Association("Contact-DemoTask")]
        public XPCollection<Contact> Contacts
        {
            get
            {
                return GetCollection<Contact>(nameof(Contacts));
            }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Priority = Priority.Normal;
        }

        private Priority priority;
        public Priority Priority
        {
            get { return priority; }
            set
            {
                SetPropertyValue(nameof(Priority), ref priority, value);
            }
        }

        [Action(ToolTip = "Postpone the task to the next day")]
        public void Postpone()
        {
            if (DueDate == DateTime.MinValue)
            {
                DueDate = DateTime.Now;
            }
            DueDate = DueDate + TimeSpan.FromDays(1);
        }

    }
    public enum Priority
    {
        [ImageName("State_Priority_Low")]
        Low = 0,
        [ImageName("State_Priority_Normal")]
        Normal = 1,
        [ImageName("State_Priority_High")]
        High = 2
    }
}