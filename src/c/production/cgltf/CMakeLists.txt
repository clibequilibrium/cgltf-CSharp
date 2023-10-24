cmake_minimum_required(VERSION 3.4)
project(cgltf C)

set(BUILD_SHARED_LIBS TRUE)

get_filename_component(CGLTF_DIRECTORY_PATH "../../../../ext/cgltf" REALPATH BASE_DIR "${CMAKE_CURRENT_SOURCE_DIR}")
include_directories(cgltf PRIVATE ${CGLTF_DIRECTORY_PATH})

add_library(${PROJECT_NAME} cgltf.c)

set_target_properties(${PROJECT_NAME}
  PROPERTIES
    C_STANDARD 11
    WINDOWS_EXPORT_ALL_SYMBOLS ON
)