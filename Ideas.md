Rooms are components (square) with 4 sides (North, East, South, West)
Rooms can be designated end rooms (bathroom, bedroom) or middle rooms (hallway, living room, kitchen)
End rooms require a minimum connection to a middle room
Middle rooms require at least 2 connections

Key Functionality:
- Login
- Setup layout of home (only one?)
- Specify location and type of sensors (in a room)

Additional Functionality:
- SOAP Web Service
    - Submit data reading
        - stored in database (with timestamp)
    - Query current state and events
    - Reset system
    - Switch system ON / OFF

Advanced Functionality:
- Check layout is "valid", i.e. you can walk through every room in house
- 

------------------------
Code prompts:

Room
+ Type: RoomType
+ Sensors: List<Sensor>
+ Connections: Array(4)<Room> - use objects?

RoomTypeEnum
- Kitchen
- Living Room
- Bathroom
- Bedroom
- Garden

Sensor
+ Type: SensorType

SensorTypeEnum
- Door/window contact
- Movement
- Fire
- Breaking glass
- Vibration

(https://en.wikipedia.org/wiki/Security_alarm)

DataReading: Sensor
- location: Point - use grid co-ords? e.g. (0,1)
- type: SensorType
- value: <SensorValue>

SystemState:
- Off
- On (Armed)
- Triggered / Active (Alert)

