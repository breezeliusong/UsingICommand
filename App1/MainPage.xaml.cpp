//
// MainPage.xaml.cpp
// Implementation of the MainPage class.
//

#include "pch.h"
#include "MainPage.xaml.h"

using namespace App1;

using namespace Platform;
using namespace Windows::Foundation;
using namespace Windows::Foundation::Collections;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::UI::Xaml::Controls::Primitives;
using namespace Windows::UI::Xaml::Data;
using namespace Windows::UI::Xaml::Input;
using namespace Windows::UI::Xaml::Media;
using namespace Windows::UI::Xaml::Navigation;
using namespace Windows::Data::Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

MainPage::MainPage()
{
	InitializeComponent();

	JsonObject^ jsonObject = ref new JsonObject();
	jsonObject->Insert("Width", JsonValue::CreateNumberValue(800));
	jsonObject->Insert("Height", JsonValue::CreateNumberValue(600));

	JsonArray^ jsonArray = ref new JsonArray();
	jsonArray->Append(JsonValue::CreateNumberValue(116));
	jsonArray->Append(JsonValue::CreateNumberValue(3.14159));
	jsonArray->Append(jsonObject);
	String^ jsonString = jsonArray->Stringify();
}
