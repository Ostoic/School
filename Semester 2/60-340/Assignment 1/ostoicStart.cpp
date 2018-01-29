#include "ostoicStart.h"

#include <Windows.h>

using namespace System;
using namespace System::Windows::Forms;

void Main()
{
	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false);
	ostoicAssignment1::ostoicStart form;
	Application::Run(%form);
}