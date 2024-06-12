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

    // tasks.register("allAndroidDependencies") {
    //     projectsToInclude.forEach { projectName ->
    //         dependsOn("$projectName:androidDependencies")
    //     }
    // }

    tasks.register("allAndroidDependencies") {
        doLast {
            projectsToInclude.forEach { projectName ->
                val project = project(projectName)
                val releaseRuntimeClasspath = project.configurations.getByName("releaseRuntimeClasspath")
                println("Dependencies for $projectName:")
                releaseRuntimeClasspath.resolvedConfiguration.resolvedArtifacts.forEach { artifact ->
                    println("${artifact.moduleVersion.id.group}:${artifact.moduleVersion.id.name}:${artifact.moduleVersion.id.version}")
                }
            }
        }
    }
}