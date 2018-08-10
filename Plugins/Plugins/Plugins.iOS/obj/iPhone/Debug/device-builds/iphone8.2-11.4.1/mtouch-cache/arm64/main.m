#include "xamarin/xamarin.h"

extern void *mono_aot_module_Plugins_iOS_info;
extern void *mono_aot_module_mscorlib_info;
extern void *mono_aot_module_Xamarin_iOS_info;
extern void *mono_aot_module_System_info;
extern void *mono_aot_module_Mono_Security_info;
extern void *mono_aot_module_System_Xml_info;
extern void *mono_aot_module_System_Core_info;
extern void *mono_aot_module_Xamarin_Forms_Platform_iOS_info;
extern void *mono_aot_module_Xamarin_Forms_Core_info;
extern void *mono_aot_module_System_Data_info;
extern void *mono_aot_module_System_Numerics_info;
extern void *mono_aot_module_OpenTK_1_0_info;
extern void *mono_aot_module_System_Net_Http_info;
extern void *mono_aot_module_System_Runtime_Serialization_info;
extern void *mono_aot_module_System_ServiceModel_Internals_info;
extern void *mono_aot_module_System_Web_Services_info;
extern void *mono_aot_module_System_Xml_Linq_info;
extern void *mono_aot_module_Xamarin_Forms_Platform_info;
extern void *mono_aot_module_Prism_Forms_info;
extern void *mono_aot_module_Prism_info;
extern void *mono_aot_module_Xamarin_Forms_Maps_iOS_info;
extern void *mono_aot_module_Xamarin_Forms_Maps_info;
extern void *mono_aot_module_Plugins_info;
extern void *mono_aot_module_Xamarin_Forms_Xaml_info;
extern void *mono_aot_module_Prism_Unity_Forms_info;
extern void *mono_aot_module_Unity_Abstractions_info;
extern void *mono_aot_module_Unity_Container_info;
extern void *mono_aot_module_Realm_info;
extern void *mono_aot_module_Remotion_Linq_info;
extern void *mono_aot_module_System_Reflection_TypeExtensions_info;
extern void *mono_aot_module_System_Runtime_CompilerServices_Unsafe_info;
extern void *mono_aot_module_Plugin_Geolocator_info;
extern void *mono_aot_module_Plugin_Permissions_info;
extern void *mono_aot_module_Realm_DataBinding_info;

void xamarin_register_modules_impl ()
{
	mono_aot_register_module (mono_aot_module_Plugins_iOS_info);
	mono_aot_register_module (mono_aot_module_mscorlib_info);
	mono_aot_register_module (mono_aot_module_Xamarin_iOS_info);
	mono_aot_register_module (mono_aot_module_System_info);
	mono_aot_register_module (mono_aot_module_Mono_Security_info);
	mono_aot_register_module (mono_aot_module_System_Xml_info);
	mono_aot_register_module (mono_aot_module_System_Core_info);
	mono_aot_register_module (mono_aot_module_Xamarin_Forms_Platform_iOS_info);
	mono_aot_register_module (mono_aot_module_Xamarin_Forms_Core_info);
	mono_aot_register_module (mono_aot_module_System_Data_info);
	mono_aot_register_module (mono_aot_module_System_Numerics_info);
	mono_aot_register_module (mono_aot_module_OpenTK_1_0_info);
	mono_aot_register_module (mono_aot_module_System_Net_Http_info);
	mono_aot_register_module (mono_aot_module_System_Runtime_Serialization_info);
	mono_aot_register_module (mono_aot_module_System_ServiceModel_Internals_info);
	mono_aot_register_module (mono_aot_module_System_Web_Services_info);
	mono_aot_register_module (mono_aot_module_System_Xml_Linq_info);
	mono_aot_register_module (mono_aot_module_Xamarin_Forms_Platform_info);
	mono_aot_register_module (mono_aot_module_Prism_Forms_info);
	mono_aot_register_module (mono_aot_module_Prism_info);
	mono_aot_register_module (mono_aot_module_Xamarin_Forms_Maps_iOS_info);
	mono_aot_register_module (mono_aot_module_Xamarin_Forms_Maps_info);
	mono_aot_register_module (mono_aot_module_Plugins_info);
	mono_aot_register_module (mono_aot_module_Xamarin_Forms_Xaml_info);
	mono_aot_register_module (mono_aot_module_Prism_Unity_Forms_info);
	mono_aot_register_module (mono_aot_module_Unity_Abstractions_info);
	mono_aot_register_module (mono_aot_module_Unity_Container_info);
	mono_aot_register_module (mono_aot_module_Realm_info);
	mono_aot_register_module (mono_aot_module_Remotion_Linq_info);
	mono_aot_register_module (mono_aot_module_System_Reflection_TypeExtensions_info);
	mono_aot_register_module (mono_aot_module_System_Runtime_CompilerServices_Unsafe_info);
	mono_aot_register_module (mono_aot_module_Plugin_Geolocator_info);
	mono_aot_register_module (mono_aot_module_Plugin_Permissions_info);
	mono_aot_register_module (mono_aot_module_Realm_DataBinding_info);

}

void xamarin_register_assemblies_impl ()
{
	guint32 exception_gchandle = 0;
	xamarin_open_and_register ("Xamarin.Forms.Platform.iOS.dll", &exception_gchandle);
	xamarin_process_managed_exception_gchandle (exception_gchandle);
	xamarin_open_and_register ("Xamarin.Forms.Maps.iOS.dll", &exception_gchandle);
	xamarin_process_managed_exception_gchandle (exception_gchandle);
	xamarin_open_and_register ("Plugin.Geolocator.dll", &exception_gchandle);
	xamarin_process_managed_exception_gchandle (exception_gchandle);

}

extern "C" void xamarin_create_classes();
void xamarin_setup_impl ()
{
	xamarin_create_classes();
	xamarin_gc_pump = FALSE;
	xamarin_init_mono_debug = TRUE;
	xamarin_executable_name = "Plugins.iOS.exe";
	mono_use_llvm = FALSE;
	xamarin_log_level = 0;
	xamarin_arch_name = "arm64";
	xamarin_marshal_objectivec_exception_mode = MarshalObjectiveCExceptionModeDisable;
	xamarin_debug_mode = TRUE;
	setenv ("MONO_GC_PARAMS", "nursery-size=512k,major=marksweep", 1);
	xamarin_supports_dynamic_registration = FALSE;
}

int main (int argc, char **argv)
{
	NSAutoreleasePool *pool = [[NSAutoreleasePool alloc] init];
	int rv = xamarin_main (argc, argv, XamarinLaunchModeApp);
	[pool drain];
	return rv;
}
void xamarin_initialize_callbacks () __attribute__ ((constructor));
void xamarin_initialize_callbacks ()
{
	xamarin_setup = xamarin_setup_impl;
	xamarin_register_assemblies = xamarin_register_assemblies_impl;
	xamarin_register_modules = xamarin_register_modules_impl;
}
