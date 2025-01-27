## **For instructions of how to install/use the project please see [WIKI](https://github.com/isir/gretaUnity/wiki)**

# Greta Unity

Simple Unity project that connects Unity3D and Greta. For more information on Greta, please see the [Greta repo](https://github.com/isir/greta/#greta)

![GretaUnity logo](https://user-images.githubusercontent.com/16133942/131155744-12f2cd5b-8e8e-49d8-8978-e846fd9ead02.png)


Welcome to the public repository of the GretaUnity project.
Greta is a virtual character engine that allows generating socio-emotional behaviors in order to build natural interactional scenario with human users.

This project integrates a Greta agent in a Unity3D environment. It was tested on Unity 2020.3.x
![UnityEditor](https://user-images.githubusercontent.com/16133942/131155909-39b70004-b3bc-4e2c-995c-b0981987bfa9.png)

# Quick start

1) Install Unity
2) Clone the repository to retrieve all files from the Greta Project.
3) Install Greta as explained [here](https://github.com/isir/greta#quick-start).
4) Run Greta with one of the "GretaUnity" configurations in `greta/bin`.
5) Open the GretaUnity project in Unity.
6) Open the `Camille` Scene in the `Scenes` folder.
7) Click run.

## Functionalities

For the moment, only two functionalities are available for the GretaUnity project, but many more are to come. GretaUnity communicates with Greta through the Thrift framework, so that if Greta plays any BML, FML or sound, it is reproduced in Unity.

### Animation from file

By using the Animation Command Tester script, you can send a relative path to a BML or FML file to Greta, press `T`, and your file will automatically be played.

### Object and gaze follower

By using the Greta Unity Object Tracker, you can track Unity objects' positions so that they are replicated in Greta, and continuously stare at a given object.
