#pragma once

#include <iostream>

namespace ostoicAssignment1 {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for ostoicStart
	/// </summary>
	public ref class ostoicStart : public System::Windows::Forms::Form
	{
	public:
		ostoicStart(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~ostoicStart()
		{
			if (components)
			{
				delete components;
			}
		}

	private:
		// Types of actions.
		delegate String^ onNumberAction(double, double);	// Arithmetic operation to perform
		delegate String^ onStringAction(String^, String^);	// String operation to perform (Concat or InvalidOperation)
		delegate void updateDisplayAction(String^);			// Which part of the display to update with text.

		updateDisplayAction^ UpdateAnswerBox = gcnew updateDisplayAction(this, &ostoicStart::SetAnswerText);
		updateDisplayAction^ UpdateComparisonImage = gcnew updateDisplayAction(this, &ostoicStart::SetComparisonImage);

		// This returns the "!Not Applicable!" text to be sent to the updateDisplay delegate.
		onStringAction^ OnInvalidOperation = gcnew onStringAction(this, &ostoicStart::InvalidOperation);

	private: System::Windows::Forms::TextBox^  textBoxVariable1;
	private: System::Windows::Forms::TextBox^  textBoxVariable2;
	private: System::Windows::Forms::MenuStrip^  menuStrip;
	private: System::Windows::Forms::ToolStripMenuItem^  editToolStripMenuItem;
	private: System::Windows::Forms::Label^  labelVariable1;
	private: System::Windows::Forms::Label^  labelVariable2;
	private: System::Windows::Forms::RadioButton^  radioButtonAdd;
	private: System::Windows::Forms::RadioButton^  radioButtonSubtract;
	private: System::Windows::Forms::RadioButton^  radioButtonMultiply;
	private: System::Windows::Forms::RadioButton^  radioButtonDivide;
	private: System::Windows::Forms::RadioButton^  radioButtonGOE;

	private: System::Windows::Forms::RadioButton^  radioButtonGT;

	private: System::Windows::Forms::RadioButton^  radioButtonNE;

	private: System::Windows::Forms::RadioButton^  radioButtonEqual;
	private: System::Windows::Forms::RadioButton^  radioButtonLT;
	private: System::Windows::Forms::RadioButton^  radioButtonLOE;
	private: System::Windows::Forms::Panel^  panel1;
	private: System::Windows::Forms::Panel^  panel2;
	private: System::Windows::Forms::Label^  labelAnswer;
	private: System::Windows::Forms::TextBox^  textBoxAnswer;
	private: System::Windows::Forms::PictureBox^  pictureBoxNA;
	private: System::Windows::Forms::PictureBox^  pictureBoxCheckmark;

	private: System::Windows::Forms::PictureBox^  pictureBoxX;


	private: System::ComponentModel::IContainer^  components;

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>


#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(ostoicStart::typeid));
			this->textBoxVariable1 = (gcnew System::Windows::Forms::TextBox());
			this->textBoxVariable2 = (gcnew System::Windows::Forms::TextBox());
			this->menuStrip = (gcnew System::Windows::Forms::MenuStrip());
			this->editToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->labelVariable1 = (gcnew System::Windows::Forms::Label());
			this->labelVariable2 = (gcnew System::Windows::Forms::Label());
			this->radioButtonAdd = (gcnew System::Windows::Forms::RadioButton());
			this->radioButtonSubtract = (gcnew System::Windows::Forms::RadioButton());
			this->radioButtonMultiply = (gcnew System::Windows::Forms::RadioButton());
			this->radioButtonDivide = (gcnew System::Windows::Forms::RadioButton());
			this->radioButtonGOE = (gcnew System::Windows::Forms::RadioButton());
			this->radioButtonGT = (gcnew System::Windows::Forms::RadioButton());
			this->radioButtonNE = (gcnew System::Windows::Forms::RadioButton());
			this->radioButtonEqual = (gcnew System::Windows::Forms::RadioButton());
			this->radioButtonLT = (gcnew System::Windows::Forms::RadioButton());
			this->radioButtonLOE = (gcnew System::Windows::Forms::RadioButton());
			this->panel1 = (gcnew System::Windows::Forms::Panel());
			this->panel2 = (gcnew System::Windows::Forms::Panel());
			this->labelAnswer = (gcnew System::Windows::Forms::Label());
			this->textBoxAnswer = (gcnew System::Windows::Forms::TextBox());
			this->pictureBoxNA = (gcnew System::Windows::Forms::PictureBox());
			this->pictureBoxCheckmark = (gcnew System::Windows::Forms::PictureBox());
			this->pictureBoxX = (gcnew System::Windows::Forms::PictureBox());
			this->menuStrip->SuspendLayout();
			this->panel1->SuspendLayout();
			this->panel2->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBoxNA))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBoxCheckmark))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBoxX))->BeginInit();
			this->SuspendLayout();
			// 
			// textBoxVariable1
			// 
			this->textBoxVariable1->Location = System::Drawing::Point(147, 48);
			this->textBoxVariable1->Name = L"textBoxVariable1";
			this->textBoxVariable1->Size = System::Drawing::Size(100, 22);
			this->textBoxVariable1->TabIndex = 1;
			this->textBoxVariable1->Text = L"Variable 1";
			// 
			// textBoxVariable2
			// 
			this->textBoxVariable2->Location = System::Drawing::Point(147, 97);
			this->textBoxVariable2->Name = L"textBoxVariable2";
			this->textBoxVariable2->Size = System::Drawing::Size(100, 22);
			this->textBoxVariable2->TabIndex = 2;
			this->textBoxVariable2->Text = L"Variable 2";
			// 
			// menuStrip
			// 
			this->menuStrip->ImageScalingSize = System::Drawing::Size(20, 20);
			this->menuStrip->Items->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(1) { this->editToolStripMenuItem });
			this->menuStrip->Location = System::Drawing::Point(0, 0);
			this->menuStrip->Name = L"menuStrip";
			this->menuStrip->Size = System::Drawing::Size(667, 28);
			this->menuStrip->TabIndex = 3;
			this->menuStrip->Text = L"menuStrip2";
			// 
			// editToolStripMenuItem
			// 
			this->editToolStripMenuItem->Name = L"editToolStripMenuItem";
			this->editToolStripMenuItem->Size = System::Drawing::Size(45, 24);
			this->editToolStripMenuItem->Text = L"Exit";
			this->editToolStripMenuItem->Click += gcnew System::EventHandler(this, &ostoicStart::editToolStripMenuItem_Click);
			// 
			// labelVariable1
			// 
			this->labelVariable1->AutoSize = true;
			this->labelVariable1->Location = System::Drawing::Point(44, 48);
			this->labelVariable1->Name = L"labelVariable1";
			this->labelVariable1->Size = System::Drawing::Size(72, 17);
			this->labelVariable1->TabIndex = 4;
			this->labelVariable1->Text = L"Variable 1";
			// 
			// labelVariable2
			// 
			this->labelVariable2->AutoSize = true;
			this->labelVariable2->Location = System::Drawing::Point(44, 97);
			this->labelVariable2->Name = L"labelVariable2";
			this->labelVariable2->Size = System::Drawing::Size(72, 17);
			this->labelVariable2->TabIndex = 5;
			this->labelVariable2->Text = L"Variable 2";
			// 
			// radioButtonAdd
			// 
			this->radioButtonAdd->AutoSize = true;
			this->radioButtonAdd->Location = System::Drawing::Point(47, 25);
			this->radioButtonAdd->Name = L"radioButtonAdd";
			this->radioButtonAdd->Size = System::Drawing::Size(54, 21);
			this->radioButtonAdd->TabIndex = 6;
			this->radioButtonAdd->TabStop = true;
			this->radioButtonAdd->Text = L"Add";
			this->radioButtonAdd->UseVisualStyleBackColor = true;
			this->radioButtonAdd->CheckedChanged += gcnew System::EventHandler(this, &ostoicStart::radioButtonAdd_CheckedChanged);
			// 
			// radioButtonSubtract
			// 
			this->radioButtonSubtract->AutoSize = true;
			this->radioButtonSubtract->Location = System::Drawing::Point(47, 74);
			this->radioButtonSubtract->Name = L"radioButtonSubtract";
			this->radioButtonSubtract->Size = System::Drawing::Size(54, 21);
			this->radioButtonSubtract->TabIndex = 7;
			this->radioButtonSubtract->TabStop = true;
			this->radioButtonSubtract->Text = L"Sub";
			this->radioButtonSubtract->UseVisualStyleBackColor = true;
			this->radioButtonSubtract->CheckedChanged += gcnew System::EventHandler(this, &ostoicStart::radioButtonSubtract_CheckedChanged);
			// 
			// radioButtonMultiply
			// 
			this->radioButtonMultiply->AutoSize = true;
			this->radioButtonMultiply->Location = System::Drawing::Point(47, 127);
			this->radioButtonMultiply->Name = L"radioButtonMultiply";
			this->radioButtonMultiply->Size = System::Drawing::Size(51, 21);
			this->radioButtonMultiply->TabIndex = 8;
			this->radioButtonMultiply->TabStop = true;
			this->radioButtonMultiply->Text = L"Mul";
			this->radioButtonMultiply->UseVisualStyleBackColor = true;
			this->radioButtonMultiply->CheckedChanged += gcnew System::EventHandler(this, &ostoicStart::radioButtonMultiply_CheckedChanged);
			// 
			// radioButtonDivide
			// 
			this->radioButtonDivide->AutoSize = true;
			this->radioButtonDivide->Location = System::Drawing::Point(47, 179);
			this->radioButtonDivide->Name = L"radioButtonDivide";
			this->radioButtonDivide->Size = System::Drawing::Size(49, 21);
			this->radioButtonDivide->TabIndex = 9;
			this->radioButtonDivide->TabStop = true;
			this->radioButtonDivide->Text = L"Div";
			this->radioButtonDivide->UseVisualStyleBackColor = true;
			this->radioButtonDivide->CheckedChanged += gcnew System::EventHandler(this, &ostoicStart::radioButtonDivide_CheckedChanged);
			// 
			// radioButtonGOE
			// 
			this->radioButtonGOE->AutoSize = true;
			this->radioButtonGOE->Location = System::Drawing::Point(62, 123);
			this->radioButtonGOE->Name = L"radioButtonGOE";
			this->radioButtonGOE->Size = System::Drawing::Size(172, 21);
			this->radioButtonGOE->TabIndex = 13;
			this->radioButtonGOE->TabStop = true;
			this->radioButtonGOE->Text = L"Greater Than or Equal";
			this->radioButtonGOE->UseVisualStyleBackColor = true;
			this->radioButtonGOE->CheckedChanged += gcnew System::EventHandler(this, &ostoicStart::radioButtonGOE_CheckedChanged);
			// 
			// radioButtonGT
			// 
			this->radioButtonGT->AutoSize = true;
			this->radioButtonGT->Location = System::Drawing::Point(62, 96);
			this->radioButtonGT->Name = L"radioButtonGT";
			this->radioButtonGT->Size = System::Drawing::Size(115, 21);
			this->radioButtonGT->TabIndex = 12;
			this->radioButtonGT->TabStop = true;
			this->radioButtonGT->Text = L"Greater Than";
			this->radioButtonGT->UseVisualStyleBackColor = true;
			this->radioButtonGT->CheckedChanged += gcnew System::EventHandler(this, &ostoicStart::radioButtonGT_CheckedChanged);
			// 
			// radioButtonNE
			// 
			this->radioButtonNE->AutoSize = true;
			this->radioButtonNE->Location = System::Drawing::Point(62, 69);
			this->radioButtonNE->Name = L"radioButtonNE";
			this->radioButtonNE->Size = System::Drawing::Size(91, 21);
			this->radioButtonNE->TabIndex = 11;
			this->radioButtonNE->TabStop = true;
			this->radioButtonNE->Text = L"Not Equal";
			this->radioButtonNE->UseVisualStyleBackColor = true;
			this->radioButtonNE->CheckedChanged += gcnew System::EventHandler(this, &ostoicStart::radioButtonNE_CheckedChanged);
			// 
			// radioButtonEqual
			// 
			this->radioButtonEqual->AutoSize = true;
			this->radioButtonEqual->CheckAlign = System::Drawing::ContentAlignment::BottomLeft;
			this->radioButtonEqual->Location = System::Drawing::Point(62, 42);
			this->radioButtonEqual->Name = L"radioButtonEqual";
			this->radioButtonEqual->Size = System::Drawing::Size(65, 21);
			this->radioButtonEqual->TabIndex = 10;
			this->radioButtonEqual->TabStop = true;
			this->radioButtonEqual->Text = L"Equal";
			this->radioButtonEqual->UseVisualStyleBackColor = true;
			this->radioButtonEqual->CheckedChanged += gcnew System::EventHandler(this, &ostoicStart::radioButtonEqual_CheckedChanged);
			// 
			// radioButtonLT
			// 
			this->radioButtonLT->AutoSize = true;
			this->radioButtonLT->Location = System::Drawing::Point(62, 150);
			this->radioButtonLT->Name = L"radioButtonLT";
			this->radioButtonLT->Size = System::Drawing::Size(96, 21);
			this->radioButtonLT->TabIndex = 14;
			this->radioButtonLT->TabStop = true;
			this->radioButtonLT->Text = L"Less Than";
			this->radioButtonLT->UseVisualStyleBackColor = true;
			this->radioButtonLT->CheckedChanged += gcnew System::EventHandler(this, &ostoicStart::radioButtonLT_CheckedChanged);
			// 
			// radioButtonLOE
			// 
			this->radioButtonLOE->AutoSize = true;
			this->radioButtonLOE->Location = System::Drawing::Point(62, 177);
			this->radioButtonLOE->Name = L"radioButtonLOE";
			this->radioButtonLOE->Size = System::Drawing::Size(153, 21);
			this->radioButtonLOE->TabIndex = 15;
			this->radioButtonLOE->TabStop = true;
			this->radioButtonLOE->Text = L"Less Than or Equal";
			this->radioButtonLOE->UseVisualStyleBackColor = true;
			this->radioButtonLOE->CheckedChanged += gcnew System::EventHandler(this, &ostoicStart::radioButtonLOE_CheckedChanged);
			// 
			// panel1
			// 
			this->panel1->Controls->Add(this->radioButtonLOE);
			this->panel1->Controls->Add(this->radioButtonLT);
			this->panel1->Controls->Add(this->radioButtonGOE);
			this->panel1->Controls->Add(this->radioButtonGT);
			this->panel1->Controls->Add(this->radioButtonNE);
			this->panel1->Controls->Add(this->radioButtonEqual);
			this->panel1->Location = System::Drawing::Point(287, 152);
			this->panel1->Name = L"panel1";
			this->panel1->Size = System::Drawing::Size(269, 251);
			this->panel1->TabIndex = 16;
			// 
			// panel2
			// 
			this->panel2->Controls->Add(this->radioButtonDivide);
			this->panel2->Controls->Add(this->radioButtonMultiply);
			this->panel2->Controls->Add(this->radioButtonSubtract);
			this->panel2->Controls->Add(this->radioButtonAdd);
			this->panel2->Location = System::Drawing::Point(10, 169);
			this->panel2->Name = L"panel2";
			this->panel2->Size = System::Drawing::Size(237, 233);
			this->panel2->TabIndex = 17;
			// 
			// labelAnswer
			// 
			this->labelAnswer->AutoSize = true;
			this->labelAnswer->Location = System::Drawing::Point(44, 137);
			this->labelAnswer->Name = L"labelAnswer";
			this->labelAnswer->Size = System::Drawing::Size(54, 17);
			this->labelAnswer->TabIndex = 18;
			this->labelAnswer->Text = L"Answer";
			// 
			// textBoxAnswer
			// 
			this->textBoxAnswer->Location = System::Drawing::Point(147, 134);
			this->textBoxAnswer->Name = L"textBoxAnswer";
			this->textBoxAnswer->ReadOnly = true;
			this->textBoxAnswer->Size = System::Drawing::Size(236, 22);
			this->textBoxAnswer->TabIndex = 19;
			// 
			// pictureBoxNA
			// 
			this->pictureBoxNA->Image = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"pictureBoxNA.Image")));
			this->pictureBoxNA->Location = System::Drawing::Point(10, 408);
			this->pictureBoxNA->Name = L"pictureBoxNA";
			this->pictureBoxNA->Size = System::Drawing::Size(192, 133);
			this->pictureBoxNA->SizeMode = System::Windows::Forms::PictureBoxSizeMode::StretchImage;
			this->pictureBoxNA->TabIndex = 20;
			this->pictureBoxNA->TabStop = false;
			this->pictureBoxNA->Visible = false;
			// 
			// pictureBoxCheckmark
			// 
			this->pictureBoxCheckmark->Image = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"pictureBoxCheckmark.Image")));
			this->pictureBoxCheckmark->Location = System::Drawing::Point(432, 48);
			this->pictureBoxCheckmark->Name = L"pictureBoxCheckmark";
			this->pictureBoxCheckmark->Size = System::Drawing::Size(199, 98);
			this->pictureBoxCheckmark->SizeMode = System::Windows::Forms::PictureBoxSizeMode::StretchImage;
			this->pictureBoxCheckmark->TabIndex = 21;
			this->pictureBoxCheckmark->TabStop = false;
			this->pictureBoxCheckmark->Visible = false;
			// 
			// pictureBoxX
			// 
			this->pictureBoxX->Image = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"pictureBoxX.Image")));
			this->pictureBoxX->Location = System::Drawing::Point(432, 48);
			this->pictureBoxX->Name = L"pictureBoxX";
			this->pictureBoxX->Size = System::Drawing::Size(199, 98);
			this->pictureBoxX->SizeMode = System::Windows::Forms::PictureBoxSizeMode::StretchImage;
			this->pictureBoxX->TabIndex = 22;
			this->pictureBoxX->TabStop = false;
			this->pictureBoxX->Visible = false;
			// 
			// ostoicStart
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(8, 16);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(667, 569);
			this->Controls->Add(this->pictureBoxX);
			this->Controls->Add(this->pictureBoxCheckmark);
			this->Controls->Add(this->pictureBoxNA);
			this->Controls->Add(this->textBoxAnswer);
			this->Controls->Add(this->labelAnswer);
			this->Controls->Add(this->panel2);
			this->Controls->Add(this->panel1);
			this->Controls->Add(this->labelVariable2);
			this->Controls->Add(this->labelVariable1);
			this->Controls->Add(this->textBoxVariable2);
			this->Controls->Add(this->textBoxVariable1);
			this->Controls->Add(this->menuStrip);
			this->Icon = (cli::safe_cast<System::Drawing::Icon^>(resources->GetObject(L"$this.Icon")));
			this->Name = L"ostoicStart";
			this->Text = L"Ostoic Assignment1 Solution";
			this->menuStrip->ResumeLayout(false);
			this->menuStrip->PerformLayout();
			this->panel1->ResumeLayout(false);
			this->panel1->PerformLayout();
			this->panel2->ResumeLayout(false);
			this->panel2->PerformLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBoxNA))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBoxCheckmark))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBoxX))->EndInit();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion

		System::Void editToolStripMenuItem_Click(System::Object^  sender, System::EventArgs^  e) 
		{
			// Close on menu->exit click
			this->Close();
		}

		// This function takes 3 delegates as parameters.
		// onNumber: this is the mathematical operation to be performed on the two variables (if TryParse determines they are not strings).
		// onString: this is the string operation to be performed on the two variables (if at least one of them is a string)
		// updateDisplay: the manner in which we update our display. If UpdateAnswerBox is passed, then the answer text will be updated
		// accordingly. If UpdateComparisonImage, a checkmark or x image will be displayed based on whether "True" or "False" is passed.
		// The boolean value is returned from the comparison operators and passed into UpdateComparisonImage.
		System::Void OnRadioCheck(onNumberAction^ onNumber, onStringAction^ onString, updateDisplayAction^ updateDisplay)
		{
			double variable1 = 0;
			double variable2 = 0;

			if (double::TryParse(this->textBoxVariable1->Text, variable1) &&
				double::TryParse(this->textBoxVariable2->Text, variable2))
			{
				updateDisplay(onNumber(variable1, variable2));
			}
			else
			{
				updateDisplay(onString(this->textBoxVariable1->Text, this->textBoxVariable2->Text));
			}
		}

		// Set the visiblity of the "not available" image.
		void SetNAImage(bool visibility)
		{
			this->pictureBoxNA->Visible = visibility;
		}

		// Set the answer text of the text box.
		void SetAnswerText(String^ text)
		{
			this->textBoxAnswer->Text = text;
		}
		
		// Set the visibility of the comparison image corresponding to the state (True or False) variable.
		// True -> checkmark image
		// False -> X image
		void SetComparisonImage(String^ state)
		{
			if (state == "True")
			{
				this->pictureBoxCheckmark->Visible = true;
				this->pictureBoxX->Visible = false;
			}
			else
			{
				this->pictureBoxX->Visible = true;
				this->pictureBoxCheckmark->Visible = false;
			}
		}

		/* Start of number and string operators */
		String^ Add(double x, double y)
		{
			this->SetNAImage(false);
			return (x + y).ToString();
		}

		String^ Concatenate(String^ x, String^ y)
		{
			this->SetNAImage(false);
			return String::Concat(x, y);
		}

		String^ Subtract(double x, double y)
		{
			this->SetNAImage(false);
			return (x - y).ToString();
		}

		String^ Multiply(double x, double y)
		{
			this->SetNAImage(false);
			return (x * y).ToString();
		}

		String^ Divide(double x, double y)
		{
			if (y == 0)
			{
				// If y is 0, set the not available image to be visible, and return an error message.
				this->SetNAImage(true);
				return "!Cannot divide by 0!";
			}

			this->SetNAImage(false);
			return (x / y).ToString();
		}

		String^ Equal(double x, double y)
		{
			return (x == y).ToString();
		}

		String^ Equal(String^ str1, String^ str2)
		{
			return (str1 == str2).ToString();
		}

		String^ NotEqual(double x, double y)
		{
			return (x != y).ToString();
		}

		String^ NotEqual(String^ str1, String^ str2)
		{
			return (str1 != str2).ToString();
		}

		String^ LessThan(double x, double y)
		{
			return (x < y).ToString();
		}

		String^ LessThan(String^ str1, String^ str2)
		{
			return (String::Compare(str1, str2) < 0).ToString();
		}

		String^ GreaterThan(double x, double y)
		{
			return (x > y).ToString();
		}

		String^ GreaterThan(String^ str1, String^ str2)
		{
			return (String::Compare(str1, str2) > 0).ToString();
		}

		String^ LessOrEqual(double x, double y)
		{
			return (x <= y).ToString();
		}

		String^ LessOrEqual(String^ str1, String^ str2)
		{
			return (String::Compare(str1, str2) < 0 || str1 == str2).ToString();
		}

		String^ GreaterOrEqual(double x, double y)
		{
			return (x >= y).ToString();
		}

		String^ GreaterOrEqual(String^ str1, String^ str2)
		{
			return (String::Compare(str1, str2) > 0 || str1 == str2).ToString();
		}
		/* End of number and string operators */

		// Set the "Not available" image and return "!Not Applicable!"
		String^ InvalidOperation(String^ x, String^ y)
		{
			this->SetNAImage(true);
			return "!Not Applicable!";
		}

		System::Void radioButtonAdd_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
		{
			onNumberAction^ onNumber = gcnew onNumberAction(this, &ostoicStart::Add);
			onStringAction^ onString = gcnew onStringAction(this, &ostoicStart::Concatenate);

			// If the add radio button was selected, update the answer box according to the variable types.
			if (this->radioButtonAdd->Checked)
				this->OnRadioCheck(onNumber, onString, UpdateAnswerBox);
		}

		System::Void radioButtonSubtract_CheckedChanged(System::Object^  sender, System::EventArgs^  e)
		{
			onNumberAction^ onNumber = gcnew onNumberAction(this, &ostoicStart::Subtract);

			// If the subtract radio button was selected, update the answer box according to the variable types.
			if (this->radioButtonSubtract->Checked)
				this->OnRadioCheck(onNumber, OnInvalidOperation, UpdateAnswerBox);
		}

		System::Void radioButtonMultiply_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
		{
			onNumberAction^ OnNumber = gcnew onNumberAction(this, &ostoicStart::Multiply);

			// If the multiply radio button was selected, update the answer box according to the variable types.
			if (this->radioButtonMultiply->Checked)
				this->OnRadioCheck(OnNumber, OnInvalidOperation, UpdateAnswerBox);
		}

		System::Void radioButtonDivide_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
		{
			onNumberAction^ OnNumber = gcnew onNumberAction(this, &ostoicStart::Divide);

			// If the divide radio button was selected, update the answer box according to the variable types.
			if (this->radioButtonDivide->Checked)
				this->OnRadioCheck(OnNumber, OnInvalidOperation, UpdateAnswerBox);
		}

		System::Void radioButtonEqual_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
		{
			onNumberAction^ OnNumber = gcnew onNumberAction(this, &ostoicStart::Equal);
			onStringAction^ OnString = gcnew onStringAction(this, &ostoicStart::Equal);

			// If the equals radio button was selected, update the comparison display image accordingly.
			if (this->radioButtonEqual->Checked)
				this->OnRadioCheck(OnNumber, OnString, UpdateComparisonImage);
		}

		System::Void radioButtonNE_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
		{
			onNumberAction^ OnNumber = gcnew onNumberAction(this, &ostoicStart::NotEqual);
			onStringAction^ OnString = gcnew onStringAction(this, &ostoicStart::NotEqual);

			// If the not equal radio button was selected, update the comparison display image accordingly.
			if (this->radioButtonNE->Checked)
				this->OnRadioCheck(OnNumber, OnString, UpdateComparisonImage);
		}

		System::Void radioButtonGT_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
		{
			onNumberAction^ OnNumber = gcnew onNumberAction(this, &ostoicStart::GreaterThan);
			onStringAction^ OnString = gcnew onStringAction(this, &ostoicStart::GreaterThan);

			// If the greater than radio button was selected, update the comparison display image accordingly.
			if (this->radioButtonGT->Checked)
				this->OnRadioCheck(OnNumber, OnString, UpdateComparisonImage);
		}

		System::Void radioButtonGOE_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
		{
			onNumberAction^ OnNumber = gcnew onNumberAction(this, &ostoicStart::GreaterOrEqual);
			onStringAction^ OnString = gcnew onStringAction(this, &ostoicStart::GreaterOrEqual);

			// If the greater or equal radio button was selected, update the comparison display image accordingly.
			if (this->radioButtonGOE->Checked)
				this->OnRadioCheck(OnNumber, OnString, UpdateComparisonImage);
		}

		System::Void radioButtonLT_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
		{
			onNumberAction^ OnNumber = gcnew onNumberAction(this, &ostoicStart::LessThan);
			onStringAction^ OnString = gcnew onStringAction(this, &ostoicStart::LessThan);

			// If the less than radio button was selected, update the comparison display image accordingly.
			if (this->radioButtonLT->Checked)
				this->OnRadioCheck(OnNumber, OnString, UpdateComparisonImage);
		}

		System::Void radioButtonLOE_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
		{
			onNumberAction^ OnNumber = gcnew onNumberAction(this, &ostoicStart::LessOrEqual);
			onStringAction^ OnString = gcnew onStringAction(this, &ostoicStart::LessOrEqual);

			// If the less or equal radio button was selected, update the comparison display image accordingly.
			if (this->radioButtonLOE->Checked)
				this->OnRadioCheck(OnNumber, OnString, UpdateComparisonImage);
		}
	};
}
