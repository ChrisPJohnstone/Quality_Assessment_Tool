using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quality_Assessment_Tool
{
    public partial class Assessment_Form : Form
    {
        Global_Variables globalVariables = new Global_Variables();
        SQL_Interaction sql = new SQL_Interaction();
        General_Functions generalFunctions = new General_Functions();

        // Declare Global Variables //
        #region Declare Global Variables
        private String formType;
        private int assessmentArea;
        private int questionSet;
        private int assessmentType;
        private bool selfAssessment;
        private bool lockQuestions;
        #endregion

        // Code When Page Launched //
        #region Code When Page Launched
        public Assessment_Form(String passThroughFormType, int passThroughAssessment, int passThroughAssessmentArea, int passThroughQuestionSet, int passThroughAssessmentType)
        {
            InitializeComponent();

            // Populate some variables //
            #region Populate some variables
            formType = passThroughFormType;

            if (passThroughFormType == "Score")
            {
                assessmentArea = passThroughAssessmentArea;
                questionSet = passThroughQuestionSet;
                assessmentType = passThroughAssessmentType;
            }
            else
            {
                String assessmentAreaQuery =
                    "SELECT [Assessment].[Assessment_Area]"
                    + "FROM [Table].[Assessment]"
                    + "WHERE [Assessment].[Assessment] = " + passThroughAssessment;

                String questionSetQuery =
                    "SELECT [Assessment].[Question_Set]"
                    + "FROM [Table].[Assessment]"
                    + "WHERE [Assessment].[Assessment] = " + passThroughAssessment;

                String assessmentTypeQuery =
                    "SELECT [Assessment].[Assessment_Type]"
                    + "FROM [Table].[Assessment]"
                    + "WHERE [Assessment].[Assessment] = " + passThroughAssessment;

                assessmentArea = sql.returnSingleInt(assessmentAreaQuery);
                questionSet = sql.returnSingleInt(questionSetQuery);
                assessmentType = sql.returnSingleInt(assessmentTypeQuery);
            }

            String assessmentTypeNameQuery =
                "SELECT [Ref_Assessment_Type].[Name]"
                + "FROM [Table].[Ref_Assessment_Type]"
                + "WHERE [Ref_Assessment_Type].[Assessment_Type] = " + assessmentType.ToString();
            if (sql.returnSingleString(assessmentTypeNameQuery) == "Self Assessment")
            {
                selfAssessment = true;
            }
            else
            {
                selfAssessment = false;
            }

            if (globalVariables.userPermissionAssessor())
            {
                lockQuestions = false;
            }
            else if (passThroughFormType == "Score" && selfAssessment)
            {
                lockQuestions = false;
            }
            else
            {
                String assessmentByQuery =
                    "SELECT [Assessment].[Assessment_By]"
                    + "FROM [Table].[Assessment]"
                    + "WHERE [Assessment].[Assessment] = " + passThroughAssessment;
                if (sql.returnSingleInt(assessmentByQuery) != globalVariables.userID(globalVariables.userName()))
                {
                    lockQuestions = false;
                }

                lockQuestions = true;
            }
            #endregion

            // Populate Assessor Field //
            String assessorQuery =
                "SELECT"
                + " [Ref_User].[User] AS [ID]"
                + " , [Ref_User].[Name]"
                + "FROM [Table].[Ref_User]"
                + "INNER JOIN [Table].[Ref_Permission]"
                + " ON [Ref_User].[Permission] = [Ref_Permission].[Permission]"
                + "WHERE"
                + " CASE"
                + "     WHEN [Ref_User].[User] = '" + globalVariables.userID(globalVariables.userName()) + "' THEN 1"
                + "     WHEN [Ref_Permission].[Assessor] = 1 THEN 1"
                + "     ELSE 0"
                + " END = 1"
                + "ORDER BY [Ref_User].[Name] ASC";
            generalFunctions.fillComboBox(AssessorComboBox, assessorQuery);
            AssessorComboBox.SelectedValue = globalVariables.userID(globalVariables.userName()).ToString();
            if (!globalVariables.userPermissionAdmin())
            {
                AssessorComboBox.Enabled = false;
            }

            // Lock Notes If Needed //
            if (lockQuestions)
            {
                NotesTextBox.Enabled = false;
            }

            // Hide Percentage If Needed //
            String questionSetNameQuery =
                "SELECT"
                + " CASE"
                + "     WHEN [Ref_Assessment_Area].[Name] LIKE '%Direct Call%' AND [Ref_Question_Set].[Name] LIKE '%Compliance%' THEN 'DC Compliance'"
                + "     ELSE 'Other'"
                + " END AS [Question_Set]"
                + "FROM [Table].[Ref_Assessment_Area]"
                + "INNER JOIN [Table].[Ref_Question_Set]"
                + " ON [Ref_Assessment_Area].[Assessment_Area] = [Ref_Question_Set].[Assessment_Area]"
                + "WHERE [Ref_Question_Set].[Question_Set] = " + questionSet.ToString();
            String questionSetName = sql.returnSingleString(questionSetNameQuery);

            if (questionSetName == "DC Compliance")
            {
                ScorePercentLabel.Visible = false;
                ScorePercentDisplay.Visible = false;
            }

            //Generate front sheet //
            generatePrimaryTab(mainTabControl, questionSet);

            // Generate questions //
            generateQuestionTabs(mainTabControl, questionSet);

            // Populate Answers For Existing Assessments //
            if (passThroughFormType != "Score")
            {
                populateAnswers(passThroughAssessment);
            }
        }
        #endregion

        // Create front tab in tab control //
        #region Create front tab in tab control
        public void generatePrimaryTab(TabControl tc, int questionSet)
        {
            TabPage newPage = new TabPage("General Information");
            tc.TabPages.Add(newPage);
            newPage.Name = "GeneralInformation";

            // Generate Distribution Channel Section //
            #region Generate Distribution Channel Section
            String distributionChannelQuery =
                "SELECT"
                + " [Ref_Distribution_Channel].[Distribution_Channel] AS [ID]"
                + " , [Ref_Distribution_Channel].[Name]"
                + "FROM [Table].[Ref_Distribution_Channel]"
                + "WHERE"
                + " [Ref_Distribution_Channel].[Question_Set] = " + questionSet
                + " AND [Ref_Distribution_Channel].[Active] = 1"
                + "ORDER BY [Ref_Distribution_Channel].[Distribution_Channel_Order]";

            Label distributionChannelLabel = new Label();
            newPage.Controls.Add(distributionChannelLabel);
            distributionChannelLabel.Name = "DistributionChannelLabel";
            distributionChannelLabel.Text = "Distribution Channel";
            distributionChannelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            distributionChannelLabel.BackColor = System.Drawing.Color.White;
            distributionChannelLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            distributionChannelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            distributionChannelLabel.AutoSize = false;
            distributionChannelLabel.Location = new System.Drawing.Point(10, 10);
            distributionChannelLabel.Size = new System.Drawing.Size(347, 24);

            ListBox distributionChannelListBox = new ListBox();
            newPage.Controls.Add(distributionChannelListBox);
            distributionChannelListBox.Name = "DistributionChannelListBox";
            generalFunctions.fillListBox(distributionChannelListBox, distributionChannelQuery);
            distributionChannelListBox.BackColor = System.Drawing.Color.White;
            distributionChannelListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            distributionChannelListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            distributionChannelListBox.Location = new System.Drawing.Point(10, 44);
            distributionChannelListBox.Size = new System.Drawing.Size(347, 100);
            if (lockQuestions)
            {
                distributionChannelListBox.Enabled = false;
            }
            #endregion

            // Generate Interaction Type Section //
            #region Generate Interaction Type Section
            String interactionTypeQuery =
                "SELECT"
                + " [Ref_Interaction_Type].[Interaction_Type] AS [ID]"
                + " , [Ref_Interaction_Type].[Name]"
                + "FROM [Table].[Ref_Interaction_Type]"
                + "WHERE [Ref_Interaction_Type].[Question_Set] = " + questionSet
                + "ORDER BY [Ref_Interaction_Type].[Interaction_Type_Order]";

            Label interactionTypeLabel = new Label();
            newPage.Controls.Add(interactionTypeLabel);
            interactionTypeLabel.Name = "InteractionTypeLabel";
            interactionTypeLabel.Text = "Interaction Type";
            interactionTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            interactionTypeLabel.BackColor = System.Drawing.Color.White;
            interactionTypeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            interactionTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            interactionTypeLabel.AutoSize = false;
            interactionTypeLabel.Location = new System.Drawing.Point(367, 10);
            interactionTypeLabel.Size = new System.Drawing.Size(347, 24);

            ListBox interactionTypeListBox = new ListBox();
            newPage.Controls.Add(interactionTypeListBox);
            interactionTypeListBox.Name = "InteractionTypeListBox";
            generalFunctions.fillListBox(interactionTypeListBox, interactionTypeQuery);
            interactionTypeListBox.BackColor = System.Drawing.Color.White;
            interactionTypeListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            interactionTypeListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            interactionTypeListBox.Location = new System.Drawing.Point(367, 44);
            interactionTypeListBox.Size = new System.Drawing.Size(347, 100);
            if (lockQuestions)
            {
                interactionTypeListBox.Enabled = false;
            }
            #endregion

            // Generate Interaction Details Section //
            #region Generate Interaction Details Section
            Label interactionDetailLabel = new Label();
            newPage.Controls.Add(interactionDetailLabel);
            interactionDetailLabel.Name = "InteractionDetailLabel";
            interactionDetailLabel.Text = "Interaction Details";
            interactionDetailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            interactionDetailLabel.BackColor = System.Drawing.Color.DarkGray;
            interactionDetailLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            interactionDetailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, System.Drawing.FontStyle.Bold);
            interactionDetailLabel.ForeColor = System.Drawing.Color.White;
            interactionDetailLabel.AutoSize = false;
            interactionDetailLabel.Location = new System.Drawing.Point(10, 154);
            interactionDetailLabel.Size = new System.Drawing.Size(704, 24);

            Label interactionDateLabel = new Label();
            newPage.Controls.Add(interactionDateLabel);
            interactionDateLabel.Name = "InteractionDateLabel";
            interactionDateLabel.Text = "Interaction Date";
            interactionDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            interactionDateLabel.BackColor = System.Drawing.Color.White;
            interactionDateLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            interactionDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
            interactionDateLabel.AutoSize = false;
            interactionDateLabel.Location = new System.Drawing.Point(10, 188);
            interactionDateLabel.Size = new System.Drawing.Size(347, 24);

            DateTimePicker interactionDatePicker = new DateTimePicker();
            newPage.Controls.Add(interactionDatePicker);
            interactionDatePicker.Name = "InteractionDateTextBox";
            interactionDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            interactionDatePicker.CustomFormat = "yyyy-MM-dd";
            interactionDatePicker.BackColor = System.Drawing.Color.White;
            interactionDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
            interactionDatePicker.Location = new System.Drawing.Point(367, 188);
            interactionDatePicker.Size = new System.Drawing.Size(347, 24);
            if (lockQuestions)
            {
                interactionDatePicker.Enabled = false;
            }

            Label interactionTimeLabel = new Label();
            newPage.Controls.Add(interactionTimeLabel);
            interactionTimeLabel.Name = "InteractionTimeLabel";
            interactionTimeLabel.Text = "Interaction Time";
            interactionTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            interactionTimeLabel.BackColor = System.Drawing.Color.White;
            interactionTimeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            interactionTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
            interactionTimeLabel.AutoSize = false;
            interactionTimeLabel.Location = new System.Drawing.Point(10, 222);
            interactionTimeLabel.Size = new System.Drawing.Size(347, 24);

            DateTimePicker interactionTimePicker = new DateTimePicker();
            newPage.Controls.Add(interactionTimePicker);
            interactionTimePicker.Name = "InteractionTimeTextBox";
            interactionTimePicker.ShowUpDown = true;
            interactionTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            interactionTimePicker.CustomFormat = "HH:mm:ss";
            interactionTimePicker.BackColor = System.Drawing.Color.White;
            interactionTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
            interactionTimePicker.Location = new System.Drawing.Point(367, 222);
            interactionTimePicker.Size = new System.Drawing.Size(347, 24);
            if (lockQuestions)
            {
                interactionTimePicker.Enabled = false;
            }

            TextBox interactionTimeTextBox = new TextBox();
            newPage.Controls.Add(interactionTimeTextBox);
            interactionTimeTextBox.Name = "InteractionTimeTextBox";
            interactionTimeTextBox.TextAlign = HorizontalAlignment.Center;
            interactionTimeTextBox.BackColor = System.Drawing.Color.White;
            interactionTimeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            interactionTimeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
            interactionTimeTextBox.Location = new System.Drawing.Point(367, 222);
            interactionTimeTextBox.Size = new System.Drawing.Size(347, 24);
            if (lockQuestions)
            {
                interactionTimeTextBox.Enabled = false;
            }
            Label agentNameLabel = new Label();
            newPage.Controls.Add(agentNameLabel);
            agentNameLabel.Name = "AgentNameLabel";
            agentNameLabel.Text = "Agent Name";
            agentNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            agentNameLabel.BackColor = System.Drawing.Color.White;
            agentNameLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            agentNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
            agentNameLabel.AutoSize = false;
            agentNameLabel.Location = new System.Drawing.Point(10, 256);
            agentNameLabel.Size = new System.Drawing.Size(347, 24);

            String agentNameQuery =
                "SELECT"
                + " [Ref_User].[User] AS [ID]"
                + " , [Ref_User].[Name]"
                + "FROM [Table].[Ref_User]"
                + "INNER JOIN [Table].[Ref_Permission]"
                + " ON [Ref_User].[Permission] = [Ref_Permission].[Permission]"
                + "WHERE"
                + " [Ref_User].[Active] = 1"
                + " AND [Ref_Permission].[Agent] = 1"
                + "ORDER BY [Ref_User].[Name] ASC";

            ComboBox agentNameComboBox = new ComboBox();
            newPage.Controls.Add(agentNameComboBox);
            agentNameComboBox.Name = "AgentNameComboBox";
            generalFunctions.fillComboBox(agentNameComboBox, agentNameQuery);
            agentNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            agentNameComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            agentNameComboBox.BackColor = System.Drawing.Color.White;
            agentNameComboBox.AutoSize = false;
            agentNameComboBox.Location = new System.Drawing.Point(367, 256);
            agentNameComboBox.Size = new System.Drawing.Size(347, 24);
            if (selfAssessment)
            {
                agentNameComboBox.SelectedValue = globalVariables.userID(globalVariables.userName()).ToString();
                agentNameComboBox.Enabled = false;
            }
            else if (lockQuestions)
            {
                agentNameComboBox.Enabled = false;
            }

            Label verintReferenceLabel = new Label();
            newPage.Controls.Add(verintReferenceLabel);
            verintReferenceLabel.Name = "VerintReferenceLabel";
            verintReferenceLabel.Text = "Verint Reference";
            verintReferenceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            verintReferenceLabel.BackColor = System.Drawing.Color.White;
            verintReferenceLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            verintReferenceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
            verintReferenceLabel.AutoSize = false;
            verintReferenceLabel.Location = new System.Drawing.Point(10, 290);
            verintReferenceLabel.Size = new System.Drawing.Size(347, 24);

            TextBox verintReferenceTextBox = new TextBox();
            newPage.Controls.Add(verintReferenceTextBox);
            verintReferenceTextBox.Name = "verintReferenceTextBox";
            verintReferenceTextBox.TextAlign = HorizontalAlignment.Center;
            verintReferenceTextBox.BackColor = System.Drawing.Color.White;
            verintReferenceTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            verintReferenceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
            verintReferenceTextBox.Location = new System.Drawing.Point(367, 290);
            verintReferenceTextBox.Size = new System.Drawing.Size(347, 24);
            if (lockQuestions)
            {
                verintReferenceTextBox.Enabled = false;
            }
            #endregion

            // Generate Submit Button //
            #region Generate Submit Button
            Button submitButton = new Button();
            newPage.Controls.Add(submitButton);
            submitButton.Name = "SubmitButton";
            submitButton.Text = "Submit";
            submitButton.BackColor = System.Drawing.Color.White;
            submitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
            submitButton.Location = new System.Drawing.Point(10, 550);
            submitButton.Size = new System.Drawing.Size(704, 50);
            submitButton.Click += new System.EventHandler(SubmitButton_Click);
            if (lockQuestions)
            {
                submitButton.Enabled = false;
            }
            #endregion
        }
        #endregion

        // Create question tabs in tab control //
        #region Create question tabs in tab control
        public void generateQuestionTabs(TabControl tc, int questionSet)
        {
            String tabQuery =
                "SELECT"
                + "[Ref_Tab].[Tab] AS [ID]"
                + ", [Ref_Tab].[Name]"
                + "FROM [Table].[Ref_Tab]"
                + "WHERE [Ref_Tab].[Question_Set] = " + questionSet
                + "ORDER BY [Ref_Tab].[Tab_Order] ASC";

            foreach (DataTable tabTable in sql.returnDataSet(tabQuery).Tables)
            {
                foreach (DataRow tabRow in tabTable.Rows)
                {
                    TabPage newPage = new TabPage(tabRow["Name"].ToString());
                    tc.TabPages.Add(newPage);
                    newPage.Name = "tab" + tabRow["ID"].ToString();

                    int locationY = 10;

                    String questionQuery =
                        "SELECT"
                        + "[Ref_Question].[Question] AS [ID]"
                        + " , [Ref_Question].[Name]"
                        + " , [Ref_Question].[Description]"
                        + " , [Ref_Question].[Answer_Set]"
                        + "FROM [Table].[Ref_Question]"
                        + "WHERE [Ref_Question].[Tab] = " + tabRow["ID"].ToString()
                        + "ORDER BY [Ref_Question].[Question_Order] ASC";
                    foreach (DataTable questionTable in sql.returnDataSet(questionQuery).Tables)
                    {
                        foreach (DataRow questionRow in questionTable.Rows)
                        {
                            Label newLabel = new Label();
                            newPage.Controls.Add(newLabel);
                            newLabel.Name = "question" + questionRow["ID"].ToString();
                            newLabel.Text = questionRow["Name"].ToString();
                            ToolTip newToolTip = new ToolTip();
                            newToolTip.AutoPopDelay = 500000000;
                            newToolTip.SetToolTip(newLabel, questionRow["Description"].ToString());
                            newLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            newLabel.BackColor = System.Drawing.Color.White;
                            newLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                            newLabel.AutoSize = false;
                            newLabel.Location = new System.Drawing.Point(10, locationY);
                            newLabel.Size = new System.Drawing.Size(347, 24);
                            newLabel.Click += delegate(object sender, EventArgs e)
                            {
                                questionClicked(questionRow["ID"].ToString());
                            };

                            String answerSetQuery =
                                "SELECT"
                                + "[Ref_Answer].[Answer] AS [ID]"
                                + " , [Ref_Answer].[Name]"
                                + "FROM [Table].[Ref_Answer]"
                                + "WHERE [Ref_Answer].[Answer_Set] = " + questionRow["Answer_Set"].ToString()
                                + "ORDER BY [Ref_Answer].[Answer_Order] ASC";

                            ComboBox newCBox = new ComboBox();
                            newPage.Controls.Add(newCBox);
                            newCBox.Name = "answer" + questionRow["ID"].ToString();
                            generalFunctions.fillComboBox(newCBox, answerSetQuery);
                            newCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                            newCBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
                            newCBox.BackColor = System.Drawing.Color.White;
                            newCBox.AutoSize = false;
                            newCBox.Location = new System.Drawing.Point(367, locationY);
                            newCBox.Size = new System.Drawing.Size(347, 24);
                            newCBox.SelectedValueChanged += new System.EventHandler(this.Answer_Changed);
                            if (lockQuestions)
                            {
                                newCBox.Enabled = false;
                            }

                            locationY = locationY + 34;
                        }
                    }
                }
            }
            Update_Score();
        }
        #endregion

        // Populate Answers For Existing Assessments //
        #region Populate Answers For Existing Records
        private void populateAnswers(int passThroughAssessment)
        {
            // Primary Tab & Notes //
            #region Primary Tab
            String generalInformationQuery =
                "SELECT"
                + " [Assessment].[Distribution_Channel]"
                + " , [Assessment].[Interaction_Type]"
                + " , [Assessment].[Interaction_Date]"
                + " , [Assessment].[Interaction_Time]"
                + " , [Assessment].[Interaction_By]"
                + " , [Assessment].[Interaction_Reference]"
                + " , [Assessment].[Notes]"
                + "FROM [Table].[Assessment]"
                + "WHERE [Assessment].[Assessment] = " + passThroughAssessment;

            foreach (DataTable table in sql.returnDataSet(generalInformationQuery).Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    this.NotesTextBox.Text = row["Notes"].ToString();

                    ListBox distributionChannelControl = mainTabControl.TabPages["GeneralInformation"].Controls["DistributionChannelListBox"] as ListBox;
                    distributionChannelControl.SelectedValue = row["Distribution_Channel"].ToString();

                    ListBox interactionTypeControl = mainTabControl.TabPages["GeneralInformation"].Controls["InteractionTypeListBox"] as ListBox;
                    interactionTypeControl.SelectedValue = row["Interaction_Type"].ToString();

                    DateTimePicker interactionDateControl = mainTabControl.TabPages["GeneralInformation"].Controls["InteractionDateTextBox"] as DateTimePicker;
                    interactionDateControl.Text = row["Interaction_Date"].ToString();

                    DateTimePicker interactionTimeControl = mainTabControl.TabPages["GeneralInformation"].Controls["InteractionTimeTextBox"] as DateTimePicker;
                    interactionTimeControl.Text = row["Interaction_Time"].ToString();

                    ComboBox interactionByControl = mainTabControl.TabPages["GeneralInformation"].Controls["AgentNameComboBox"] as ComboBox;
                    interactionByControl.SelectedValue = row["Interaction_By"].ToString();

                    TextBox verintReferenceControl = mainTabControl.TabPages["GeneralInformation"].Controls["verintReferenceTextBox"] as TextBox;
                    verintReferenceControl.Text = row["Interaction_Reference"].ToString();
                    verintReferenceControl.Enabled = false;
                }
            }
            #endregion

            // Question Tabs //
            #region Question Tabs
            String assessmentDetailQuery =
                "SELECT"
                + " [Ref_Question].[Tab]"
                + " , [Assessment_Detail].[Question]"
                + " , [Assessment_Detail].[Answer]"
                + "FROM [Table].[Assessment_Detail]"
                + "INNER JOIN [Table].[Ref_Question]"
                + " ON [Assessment_Detail].[Question] = [Ref_Question].[Question]"
                + "WHERE [Assessment_Detail].[Assessment] = " + passThroughAssessment
                + "ORDER BY 1, 2";

            foreach (DataTable table in sql.returnDataSet(assessmentDetailQuery).Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    ComboBox answerBox = mainTabControl.TabPages["tab" + row["Tab"].ToString()].Controls["answer" + row["Question"].ToString()] as ComboBox;
                    answerBox.SelectedValue = row["Answer"].ToString();
                }
            }
            #endregion
        }
        #endregion

        // Code When Answers Changed //
        #region Code To Update Score When Answers Changed
        private void Answer_Changed(object sender, EventArgs e)
        {
            Update_Score();
        }
        #endregion

        // Code for exporting all questions //
        #region Code for exporting all questions
        private void QuestionExportButton_Click(object sender, EventArgs e)
        {
            String questionDetailQuery =
                "SELECT"
                + " [Ref_Question].[Name]"
                + " , [Ref_Question].[Description]"
                + "FROM [Table].[Ref_Question_Set]"
                + "INNER JOIN [Table].[Ref_Tab]"
                + " ON [Ref_Question_Set].[Question_Set] = [Ref_Tab].[Question_Set]"
                + "INNER JOIN [Table].[Ref_Question]"
                + " ON [Ref_Tab].[Tab] = [Ref_Question].[Tab]"
                + "WHERE [Ref_Question_Set].[Question_Set] = " + questionSet.ToString()
                + "ORDER BY"
                + " [Ref_Question].[Tab] ASC"
                + " , [Ref_Question].[Question_Order] ASC";

            String outputString = "";
            int question = 0;
            foreach (DataTable table in sql.returnDataSet(questionDetailQuery).Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    question = question + 1;
                    outputString = outputString + "Question " + question.ToString() + ":" + Environment.NewLine + "\t" + row["Name"].ToString() + Environment.NewLine;
                    outputString = outputString + "\t" + row["Description"].ToString() + Environment.NewLine + Environment.NewLine;
                }
            }

            String filePath = "C:\\Users\\" + Environment.UserName + "\\Downloads\\";
            String fileName = "Quality_Assessment_Question.txt";
            System.IO.File.WriteAllText(filePath + fileName, outputString);
            System.Diagnostics.Process.Start(filePath + fileName);
        }
        #endregion

        // Code for exporting individual questions //
        #region Code for for exporting individual questions
        private void questionClicked(String questionNumber)
        {
            String questionDetailQuery =
                "SELECT"
                + " [Ref_Question].[Name]"
                + " , [Ref_Question].[Description]"
                + "FROM [Table].[Ref_Question]"
                + "WHERE [Ref_Question].[Question] = " + questionNumber;

            String outputString = "";
            foreach (DataTable table in sql.returnDataSet(questionDetailQuery).Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    outputString = outputString + "Question:" + Environment.NewLine + "\t" + row["Name"].ToString() + Environment.NewLine + Environment.NewLine;
                    outputString = outputString + "Description:" + Environment.NewLine + "\t" + row["Description"].ToString() + Environment.NewLine + Environment.NewLine;
                }
            }

            String filePath = "C:\\Users\\" + globalVariables.userName() + "\\Downloads\\";
            String fileName = "Quality_Assessment_Question.txt";
            generalFunctions.openStringInNotepad(filePath + fileName, outputString);
        }
        #endregion

        // Code To Update Score & Outcome //
        #region Code To Update Score & Outcome
        private void Update_Score()
        {
            int score = 0;
            int maxScore = 0;
            int incomplete = 0;
            Boolean failCatch = false;

            // Create Table To Check Fail Limits //
            #region Create Table To Check Fail Limits
            DataTable failTable = new DataTable();
            failTable.Columns.Add("Fail_Limit");
            failTable.Columns.Add("Count");

            String failLimitQuery =
                "SELECT DISTINCT"
                + " [Ref_Answer_Weight].[Fail_Limit]"
                + " , '0' AS [Count]"
                + "FROM [Table].[Ref_Question_Set]"
                + "INNER JOIN [Table].[Ref_Tab]"
                + " ON [Ref_Question_Set].[Question_Set] = [Ref_Tab].[Question_Set]"
                + "INNER JOIN [Table].[Ref_Question]"
                + " ON [Ref_Tab].[Tab] = [Ref_Question].[Tab]"
                + "INNER JOIN [Table].[Ref_Answer]"
                + " ON [Ref_Question].[Answer_Set] = [Ref_Answer].[Answer_Set]"
                + "INNER JOIN [Table].[Ref_Answer_Weight]"
                + " ON [Ref_Answer].[Answer_Weight] = [Ref_Answer_Weight].[Answer_Weight]"
                + "WHERE"
                + " [Ref_Question_Set].[Question_Set] = " + questionSet.ToString()
                + " AND [Ref_Answer_Weight].[Fail_Limit] > 0";

            foreach (DataTable failLimits in sql.returnDataSet(failLimitQuery).Tables)
            {
                foreach (DataRow row in failLimits.Rows)
                {
                    failTable.ImportRow(row);
                }
            }
            #endregion

            // Loop Through Questions To Get Score //
            #region Loop Through Questions To Get Score
            String questionQuery =
                "SELECT"
                + " [Ref_Question].[Tab]"
                + " , [Ref_Question].[Question]"
                + "FROM [Table].[Ref_Question_Set]"
                + "INNER JOIN [Table].[Ref_Tab]"
                + " ON [Ref_Question_Set].[Question_Set] = [Ref_Tab].[Question_Set]"
                + "INNER JOIN [Table].[Ref_Question]"
                + " ON [Ref_Tab].[Tab] = [Ref_Question].[Tab]"
                + "WHERE [Ref_Question_Set].[Question_Set] = " + questionSet
                + "ORDER BY [Ref_Question].[Question] ASC";

            foreach (DataTable questionTable in sql.returnDataSet(questionQuery).Tables)
            {
                foreach (DataRow questionRow in questionTable.Rows)
                {
                    ComboBox answerBox = mainTabControl.TabPages["tab" + questionRow["Tab"].ToString()].Controls["answer" + questionRow["Question"].ToString()] as ComboBox;
                    String answer = ((KeyValuePair<string, string>)answerBox.SelectedItem).Key;

                    if (answer == "0")
                    {
                        // Get Max Score For Question Based On Answer Set //
                        String potentialScoreQuery =
                            "SELECT MAX([Ref_Answer_Weight].[Max_Score_Value])"
                            + "FROM [Table].[Ref_Question]"
                            + "INNER JOIN [Table].[Ref_Answer]"
                            + "  ON [Ref_Question].[Answer_Set] = [Ref_Answer].[Answer_Set]"
                            + "INNER JOIN [Table].[Ref_Answer_Weight]"
                            + "  ON [Ref_Answer].[Answer_Weight] = [Ref_Answer_Weight].[Answer_Weight]"
                            + "WHERE [Ref_Question].[Question] ='" + questionRow["Question"].ToString() + "'";
                        maxScore = maxScore + sql.returnSingleInt(potentialScoreQuery);
                        incomplete = incomplete + 1;
                    }
                    else
                    {
                        String answerWeightQuery =
                            "SELECT"
                            + " [Ref_Answer_Weight].[Score_Value]"
                            + " , [Ref_Answer_Weight].[Max_Score_Value]"
                            + " , [Ref_Answer_Weight].[Fail_Limit]"
                            + "FROM [Table].[Ref_Answer]"
                            + "INNER JOIN [Table].[Ref_Answer_Weight]"
                            + " ON [Ref_Answer].[Answer_Weight] = [Ref_Answer_Weight].[Answer_Weight]"
                            + "WHERE [Ref_Answer].[Answer] = " + answer;

                        foreach (DataTable answerTable in sql.returnDataSet(answerWeightQuery).Tables)
                        {
                            foreach (DataRow answerRow in answerTable.Rows)
                            {
                                score = score + int.Parse(answerRow["Score_Value"].ToString());
                                maxScore = maxScore + int.Parse(answerRow["Max_Score_Value"].ToString());

                                foreach (DataRow failRow in failTable.Rows)
                                {
                                    if (failRow["Fail_Limit"].ToString() == answerRow["Fail_Limit"].ToString())
                                    {
                                        failRow["Count"] = int.Parse(failRow["Count"].ToString()) + 1;

                                        if (int.Parse(failRow["Count"].ToString()) >= int.Parse(failRow["Fail_Limit"].ToString()))
                                        {
                                            failCatch = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            int pointsMissed = maxScore - score;
            this.ScoreDisplay.Text = score.ToString();
            this.MaxScoreDisplay.Text = maxScore.ToString();

            decimal scorePercentage = (decimal.Parse(score.ToString()) / decimal.Parse(maxScore.ToString())) * 100;
            this.ScorePercentDisplay.Text = decimal.Round(scorePercentage, 2).ToString() + '%';

            // Determine Outcome //
            #region Determine Outcome
            Boolean continueChecking = true;            
            String questionSetTypeQuery =
                "SELECT"
                + " CASE"
                + "     WHEN [Ref_Question_Set].[Assessment_Area] <> 2 AND [Ref_Question_Set].[Name] = 'Customer Experience' THEN 'Customer Experience'"
                + "     ELSE 'Fail Limit Only'"
                + " END AS [Question_Set_Type]"
                + "FROM [Table].[Ref_Question_Set]"
                + "WHERE [Ref_Question_Set].[Question_Set] = " + questionSet;
            String questionSetType = sql.returnSingleString(questionSetTypeQuery);

            // Catch Incomplete //
            if (continueChecking && incomplete > 0)
            {
                this.OutcomeDisplay.Text = "Incomplete";
                this.OutcomeDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold);
                this.OutcomeDisplay.ForeColor = System.Drawing.Color.Orange;
                continueChecking = false;
            }

            // Catch Fails Early //
            if (continueChecking && failCatch)
            {
                this.OutcomeDisplay.Text = "Development" + Environment.NewLine + "Required";
                this.OutcomeDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
                this.OutcomeDisplay.ForeColor = System.Drawing.Color.Red;
                continueChecking = false;
            }

            // Customer Experience Scoring //
            if (continueChecking && questionSetType == "Customer Experience")
            {
                continueChecking = false;
                if (pointsMissed >= 3)
                {
                    this.OutcomeDisplay.Text = "Development" + Environment.NewLine + "Required";
                    this.OutcomeDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
                    this.OutcomeDisplay.ForeColor = System.Drawing.Color.Red;
                }
                else if (pointsMissed >= 2)
                {
                    this.OutcomeDisplay.Text = "1 Star";
                    this.OutcomeDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
                    this.OutcomeDisplay.ForeColor = System.Drawing.Color.Gold;
                }
                else if (pointsMissed >= 1)
                {
                    this.OutcomeDisplay.Text = "2 Stars";
                    this.OutcomeDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
                    this.OutcomeDisplay.ForeColor = System.Drawing.Color.Gold;
                }
                else if (pointsMissed == 0)
                {
                    this.OutcomeDisplay.Text = "3 Stars";
                    this.OutcomeDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
                    this.OutcomeDisplay.ForeColor = System.Drawing.Color.Gold;
                }
            }

            // Fail Limit Only Scoring //
            if (continueChecking)
            {
                continueChecking = false;
                this.OutcomeDisplay.Text = "Pass";
                this.OutcomeDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
                this.OutcomeDisplay.ForeColor = System.Drawing.Color.Green;
            }
            #endregion
        }
        #endregion

        // Code When Submit Button Clicked //
        #region Code When Submit Button Clicked
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            Boolean updateQueryCheck = true;
            String userID = globalVariables.userID(globalVariables.userName()).ToString();

            String questionQuery =
                "SELECT"
                + " [Ref_Question].[Tab]"
                + " , [Ref_Question].[Question]"
                + "FROM [Table].[Ref_Question_Set]"
                + "INNER JOIN [Table].[Ref_Tab]"
                + " ON [Ref_Question_Set].[Question_Set] = [Ref_Tab].[Question_Set]"
                + "INNER JOIN [Table].[Ref_Question]"
                + " ON [Ref_Tab].[Tab] = [Ref_Question].[Tab]"
                + "WHERE [Ref_Question_Set].[Question_Set] = " + questionSet
                + "ORDER BY [Ref_Question].[Question] ASC";

            int questionsNotAnswered = 0;
            String questionsNotAnsweredList = "";

            // Check Fields on Primary Tab //
            #region Check Fields on Primary Tab
            ListBox distributionChannelControl = mainTabControl.TabPages["GeneralInformation"].Controls["DistributionChannelListBox"] as ListBox;
            String distributionChannel = ((KeyValuePair<string, string>)distributionChannelControl.SelectedItem).Key;
            if (distributionChannel.Length == 0)
            {
                questionsNotAnswered = questionsNotAnswered + 1;
                questionsNotAnsweredList = questionsNotAnsweredList + "Distribution Channel" + Environment.NewLine;
            }

            ListBox interactionTypeControl = mainTabControl.TabPages["GeneralInformation"].Controls["InteractionTypeListBox"] as ListBox;
            String interactionType = ((KeyValuePair<string, string>)interactionTypeControl.SelectedItem).Key;
            if (interactionType.Length == 0)
            {
                questionsNotAnswered = questionsNotAnswered + 1;
                questionsNotAnsweredList = questionsNotAnsweredList + "Interaction Type" + Environment.NewLine;
            }

            DateTimePicker interactionDateControl = mainTabControl.TabPages["GeneralInformation"].Controls["InteractionDateTextBox"] as DateTimePicker;
            String interactionDate = interactionDateControl.Text.ToString();
            interactionDate = interactionDate.Substring(6,4) + "-" + interactionDate.Substring(3,2) + "-" + interactionDate.Substring(0, 2);
            if (interactionDate.Length == 0)
            {
                questionsNotAnswered = questionsNotAnswered + 1;
                questionsNotAnsweredList = questionsNotAnsweredList + "Interaction Date" + Environment.NewLine;
            }

            DateTimePicker interactionTimeControl = mainTabControl.TabPages["GeneralInformation"].Controls["InteractionTimeTextBox"] as DateTimePicker;
            String interactionTime = interactionTimeControl.Text.ToString();
            if (interactionTime.Length == 0)
            {
                questionsNotAnswered = questionsNotAnswered + 1;
                questionsNotAnsweredList = questionsNotAnsweredList + "Interaction Time" + Environment.NewLine;
            }

            ComboBox interactionByControl = mainTabControl.TabPages["GeneralInformation"].Controls["AgentNameComboBox"] as ComboBox;
            String interactionBy = ((KeyValuePair<string, string>)interactionByControl.SelectedItem).Key;
            if (interactionBy == "0")
            {
                questionsNotAnswered = questionsNotAnswered + 1;
                questionsNotAnsweredList = questionsNotAnsweredList + "Agent Name" + Environment.NewLine;
            }

            TextBox verintReferenceControl = mainTabControl.TabPages["GeneralInformation"].Controls["verintReferenceTextBox"] as TextBox;
            String verintReference = verintReferenceControl.Text.ToString();
            if (verintReference.Length == 0)
            {
                questionsNotAnswered = questionsNotAnswered + 1;
                questionsNotAnsweredList = questionsNotAnsweredList + "Verint Reference" + Environment.NewLine;
            }
            else
            {
                verintReference = verintReference.Replace("'", "''");

                String assessmentTypeQuery =
                    "SELECT [Ref_Assessment_Type].[Name]"
                    + "FROM [Table].[Ref_Assessment_Type]"
                    + "WHERE [Ref_Assessment_Type].[Assessment_Type] = " + assessmentType.ToString();
                String assessmentTypeName = sql.returnSingleString(assessmentTypeQuery);

                if (formType == "Score" && assessmentTypeName == "Benchmarking")
                {
                    userID = ((KeyValuePair<string, string>)AssessorComboBox.SelectedItem).Key;
                    verintReference = verintReference + "_BENCHMARK_" + userID;
                }
            }
            #endregion

            String insertAssessmentDetailQuery =
                "INSERT INTO [Table].[Assessment_Detail] (" + Environment.NewLine
                + " [Import_Date]" + Environment.NewLine
                + " , [Import_Time]" + Environment.NewLine
                + " , [Added_By]" + Environment.NewLine
                + " , [Assessment]" + Environment.NewLine
                + " , [Question]" + Environment.NewLine
                + " , [Answer]" + Environment.NewLine
                + ") VALUES (" + Environment.NewLine;

            foreach (DataTable table in sql.returnDataSet(questionQuery).Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    ComboBox answerBox = mainTabControl.TabPages["tab" + row["Tab"].ToString()].Controls["answer" + row["Question"].ToString()] as ComboBox;
                    String answer = ((KeyValuePair<string, string>)answerBox.SelectedItem).Key;
                    if (answer == "0")
                    {
                        Label questionBox = mainTabControl.TabPages["tab" + row["Tab"].ToString()].Controls["question" + row["Question"].ToString()] as Label;
                        questionsNotAnswered = questionsNotAnswered + 1;
                        questionsNotAnsweredList = questionsNotAnsweredList + questionBox.Text + Environment.NewLine;
                    }
                    else
                    {
                        insertAssessmentDetailQuery = insertAssessmentDetailQuery + "   CAST(GETDATE() AS DATE)" + Environment.NewLine;
                        insertAssessmentDetailQuery = insertAssessmentDetailQuery + "   , CAST(GETDATE() AS TIME(0))" + Environment.NewLine;
                        insertAssessmentDetailQuery = insertAssessmentDetailQuery + "   , SYSTEM_USER" + Environment.NewLine;
                        insertAssessmentDetailQuery = insertAssessmentDetailQuery + "   , 'PLACEHOLDERFORASSESSMENTNUMBER'" + Environment.NewLine;
                        insertAssessmentDetailQuery = insertAssessmentDetailQuery + "   , '" + row["Question"].ToString() + "'" + Environment.NewLine;
                        insertAssessmentDetailQuery = insertAssessmentDetailQuery + "   , '" + answer + "'" + Environment.NewLine;
                        insertAssessmentDetailQuery = insertAssessmentDetailQuery + "), (" + Environment.NewLine;
                    }
                }
           }

            if (questionsNotAnswered != 0)
            {
                String questionsNotAnsweredMessage =
                    "You have not answered " + questionsNotAnswered.ToString() + " questions" + Environment.NewLine
                    + "Results not submitted" + Environment.NewLine + Environment.NewLine
                    + questionsNotAnsweredList;
                MessageBox.Show(questionsNotAnsweredMessage);
            }
            else
            {
                String interactionReferenceQuery =
                    "SELECT [Assessment].[Assessment]"
                    + "FROM [Table].[Assessment]"
                    + "WHERE [Assessment].[Interaction_Reference] = '" + verintReference + "'";
                String assessmentNumber = sql.returnSingleInt(interactionReferenceQuery).ToString();

                // Settings if Assessment Already Exists in SQL //
                #region Settings if Assessment Already Exists in SQL
                Boolean emptyTableCheck = false;

                if (assessmentNumber != "0")
                {
                    // Score Settings //
                    #region Score Settings
                    if (formType == "Score")
                    {
                        String questionsNotAnsweredMessage =
                            "This verint reference already exists in the database" + Environment.NewLine
                            + "Would you like to update the existing record?" + Environment.NewLine + Environment.NewLine
                            + questionsNotAnsweredList;
                        DialogResult updateResponse = MessageBox.Show(questionsNotAnsweredMessage, "Update Existing", MessageBoxButtons.YesNo);

                        if (updateResponse == DialogResult.Yes)
                        {
                            emptyTableCheck = true;
                        }
                        else
                        {
                            updateQueryCheck = false;
                        }
                    }
                    #endregion

                    // Review Settings //
                    #region Review Settings
                    if (formType == "Review")
                    {
                        emptyTableCheck = true;
                    }
                    #endregion
                }
                #endregion

                // Deletes Existing Assessment If Opt To //
                #region Deletes Existing Assessment If Opt To
                if (emptyTableCheck)
                {
                    assessmentNumber = sql.returnSingleInt(interactionReferenceQuery).ToString();

                    String deleteAssessmentDetailQuery =
                        "DELETE FROM [Table].[Assessment_Detail]"
                        + "WHERE [Assessment_Detail].[Assessment] = " + assessmentNumber;
                    sql.updateSQL(deleteAssessmentDetailQuery);

                    String deleteAssessmentQuery =
                        "DELETE FROM [Table].[Assessment]"
                        + "WHERE [Assessment].[Assessment] = " + assessmentNumber;
                    sql.updateSQL(deleteAssessmentQuery);
                }
                #endregion

                // Inserts Assessment in to SQL //
                #region Inserts Assessment in to SQL
                if (updateQueryCheck)
                {
                    String outcome = OutcomeDisplay.Text;
                    if (outcome == "Development" + Environment.NewLine + "Required")
                    {
                        outcome = "Development Required";
                    }

                    String insertAssessmentQuery =
                        "INSERT INTO [Table].[Assessment] (" + Environment.NewLine
                        + " [Import_Date]" + Environment.NewLine
                        + " , [Import_Time]" + Environment.NewLine
                        + " , [Added_By]" + Environment.NewLine
                        + " , [Assessment_Date]" + Environment.NewLine
                        + " , [Assessment_Time]" + Environment.NewLine
                        + " , [Assessment_By]" + Environment.NewLine
                        + " , [Assessment_Area]" + Environment.NewLine
                        + " , [Question_Set]" + Environment.NewLine
                        + " , [Assessment_Type]" + Environment.NewLine
                        + " , [Interaction_Date]" + Environment.NewLine
                        + " , [Interaction_Time]" + Environment.NewLine
                        + " , [Interaction_By]" + Environment.NewLine
                        + " , [Interaction_Reference]" + Environment.NewLine
                        + " , [Distribution_Channel]" + Environment.NewLine
                        + " , [Interaction_Type]" + Environment.NewLine
                        + " , [Outcome]" + Environment.NewLine
                        + " , [Signed_Off]" + Environment.NewLine
                        + " , [Notes]" + Environment.NewLine
                        + ") VALUES (" + Environment.NewLine
                        + " CAST(GETDATE() AS DATE)" + Environment.NewLine
                        + " , CAST(GETDATE() AS TIME(0))" + Environment.NewLine
                        + " , SYSTEM_USER" + Environment.NewLine
                        + " , CAST(GETDATE() AS DATE)" + Environment.NewLine
                        + " , CAST(GETDATE() AS TIME(0))" + Environment.NewLine
                        + " , '" + userID + "'" + Environment.NewLine
                        + " , '" + assessmentArea + "'" + Environment.NewLine
                        + " , '" + questionSet + "'" + Environment.NewLine
                        + " , '" + assessmentType + "'" + Environment.NewLine
                        + " , CAST('" + interactionDate + "' AS DATE)" + Environment.NewLine
                        + " , CAST('" + interactionTime + "' AS TIME(0))" + Environment.NewLine
                        + " , '" + interactionBy + "'" + Environment.NewLine
                        + " , '" + verintReference + "'" + Environment.NewLine
                        + " , '" + distributionChannel + "'" + Environment.NewLine
                        + " , '" + interactionType + "'" + Environment.NewLine
                        + " , '" + outcome + "'" + Environment.NewLine
                        + " , '0'"
                        + " , '" + NotesTextBox.Text.Replace("'", "''") + "'" + Environment.NewLine
                        + ")";
                    sql.updateSQL(insertAssessmentQuery);

                    assessmentNumber = sql.returnSingleInt(interactionReferenceQuery).ToString();
                    insertAssessmentDetailQuery = insertAssessmentDetailQuery.Substring(0, insertAssessmentDetailQuery.Length - 5);
                    insertAssessmentDetailQuery = insertAssessmentDetailQuery.Replace("PLACEHOLDERFORASSESSMENTNUMBER", assessmentNumber);
                    sql.updateSQL(insertAssessmentDetailQuery);

                    MessageBox.Show("Assessment Submitted");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Assessment Not Submitted");
                }
                #endregion
            }
        }
        #endregion
    }
}
