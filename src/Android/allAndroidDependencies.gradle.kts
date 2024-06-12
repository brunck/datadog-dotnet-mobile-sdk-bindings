// add the following code to build.gradle.kts, at top-level scope in the file:
// apply(from = "allAndroidDependencies.gradle.kts")

gradle.projectsEvaluated {
    val projectsToInclude = setOf(
        ":dd-sdk-android-core",
        ":features:dd-sdk-android-rum",
        ":features:dd-sdk-android-logs",
        ":features:dd-sdk-android-ndk",
        ":features:dd-sdk-android-trace",
        ":features:dd-sdk-android-webview",
        ":features:dd-sdk-android-session-replay",
        ":features:dd-sdk-android-session-replay-material"
    )

    tasks.register("allAndroidDependencies") {
        doLast {
            projectsToInclude.forEach { projectName ->
                val project = project(projectName)
                val releaseRuntimeClasspath = project.configurations.getByName("releaseRuntimeClasspath")
                println("Dependencies for $projectName:")
                releaseRuntimeClasspath.resolvedConfiguration.lenientConfiguration.allModuleDependencies.forEach { dependency ->
                    printDependencyTree(dependency, "")
                }
            }
        }
    }
}

fun printDependencyTree(dependency: ResolvedDependency, indent: String) {
    println("$indent- ${dependency.moduleGroup}:${dependency.moduleName}:${dependency.moduleVersion}")
    dependency.children.forEach { child ->
        printDependencyTree(child, "$indent  ")
    }
}