MOVEMENT BEHAVIORS:

This scene involves 5 AI.  At the top of the scene, an AI is moving between a set of points by following a waypoint route.  In the middle of the scene, an AI is moving between a set of points by simply moving to them in turn, one after another.  At the bottom of the scene, an AI is moving between a set of points but is also using a Navigation Mesh to avoid obstacles between the points.  One one side there is an AI following a Patrol Route from start to finish (One-Way following).  On the other side there is an AI using a Waypoint Path to traverse a bridge en-route to a target.


PATROL BEHAVIORS:

This scene involves 4 AI types.  The Blue AI patrols the outside of the wall.  The Green AI wander randomly.  The Red AI patrols the inside of the wall.  The Yellow AI wanders and moves toward sounds it hears.

Blue AI: If the Blue AI ever detects a person of interest (anything with a Visual Aspect of "person") it will begin following that person.  The Blue AI will stop and lose interest after 5-8 seconds, but may then continue following if a person of interest is still detected.  If no person of interest is detect, the Blue AI will go back to patrolling.

Green AI: The Green AI move randomly through the scene, pausing at each random destination.  If the Green AI sees an "evil person" (anything with a Visual Aspect of "evil") it will run away.

Red AI: The Red AI will patrol the inside of the wall, stopping whenever it notices a "point of interest" (anything with a Visual Aspect of "poi").  It will look for a "standhere" point on the point of interest (an associated "stand here" aspect) and will move to that point, stand, and face the point of interest for 2 seconds before moving on.  The Red AI does not run from the Blue AI when followed.

Yellow AI: The Yellow AI will move randomly through the scene.  It uses an audio sensor to detect sounds coming from the two middle posts.  When it hears a sound, it will move toward it, then pause.


MULTI NAVMESH:

The multi navmesh scene is intended to demonstrate how to use multiple navmeshes with Graph Tags to support different AI types/sizes.  In this scene, 3 different sized AI pick random locations to move to.  The ThinMan AI uses the Thin mesh (red) and can move freely between obstacles.  The FatMan AI uses the Fat mesh (green) and can't move between the long rectangular obstacles.  The JumboMan AI uses the Jumbo mesh (blue) and can't move in between obstacles.  

Each Navmesh is tagged (Graph Tags) to indicate which AI size it supports.  The ThinMan AI can use any mesh to navigate (empty Graph Tags).  The FatMan AI can use the Fat or Jumbo meshes (Graph Tags fat, jumbo).  The JumboMan AI can only use the Jumbo mesh (Graph Tags jumbo).
