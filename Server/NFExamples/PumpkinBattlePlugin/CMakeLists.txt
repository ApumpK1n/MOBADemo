set(ProjectName "PumpkinBattlePlugin")
file(GLOB PumpkinBattlePlugin_ROOT_Cpp
	*.cpp)
	
file(GLOB PumpkinBattlePlugin_ROOT_Hpp 
	*.h)

add_library(PumpkinBattlePlugin STATIC
	${PumpkinBattlePlugin_ROOT_Cpp}
	${PumpkinBattlePlugin_ROOT_Hpp})
	
set_target_properties( PumpkinBattlePlugin PROPERTIES OUTPUT_NAME_DEBUG "PumpkinBattlePlugin")
set_target_properties( PumpkinBattlePlugin PROPERTIES PREFIX "")
set_target_properties( PumpkinBattlePlugin PROPERTIES
	FOLDER "NFExamples/PumpkinBattlePlugin"
	ARCHIVE_OUTPUT_DIRECTORY ${NFOutPutDir}
	RUNTIME_OUTPUT_DIRECTORY ${NFOutPutDir}
	LIBRARY_OUTPUT_DIRECTORY ${NFOutPutDir} )
	
link_NFSDK("PumpkinBattlePlugin")

if(UNIX)

	target_link_libraries(PumpkinBattlePlugin -static-libstdc++)

	add_definitions(
		-D_USRDLL
		-DELPP_NO_DEFAULT_LOG_FILE
	)
	
else()

	target_link_libraries(PumpkinBattlePlugin -static-libstdc++)

	add_definitions(
		-DWIN
		-D_USRDLL
		-DELPP_NO_DEFAULT_LOG_FILE
	)
endif()
