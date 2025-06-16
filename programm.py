from smbus2 import SMBus
import STS1_Sensors as STS1
import math
import time
from flask import Flask,jsonify

app = Flask(__name__)

@app.route("/")
def index():
    with SMBus(1) as bus:
        
        
        sensors = STS1.Sensors(bus)
        sensors.disable_BMM150()
        sensors.disable_GUVA_C32()
        sensors.setup()
        
        val = sensors.getData()
        accx = val.accX
        accy = val.accY
        accz = val.accZ - 200
        magx = val.magX
        magy = val.magY
        magz = val.magZ
        temp = round(val.tempBME, 2)
        data = {"Temperature": temp, "AccelerationX": accx, "AccelerationY": accy, "AccelerationZ": accz, "Magnetic FieldX": magx, "Magnetic FieldY": magy, "Magnetic FieldZ": magz}


        return jsonify({"Temp": temp, "Acc_X": accx,"Acc_Y": accy,"Acc_Z": accz, "MagX": magx, "MagY": magy, "MagZ": magz})

@app.route("/getMeasurements")
def get_measurements():

    with SMBus(1) as bus:
        
        
        sensors = STS1.Sensors(bus)
        sensors.disable_BMM150()
        sensors.disable_GUVA_C32()
        sensors.setup()
        
        val = sensors.getData()
        accx = val.accX
        accy = val.accY
        accz = val.accZ - 200
        magx = val.magX
        magy = val.magY
        magz = val.magZ
        temp = round(val.tempBME, 2)
        data = {"Temperature": temp, "AccelerationX": accx, "AccelerationY": accy, "AccelerationZ": accz, "Magnetic FieldX": magx, "Magnetic FieldY": magy, "Magnetic FieldZ": magz}


        return jsonify({"Temp": temp, "Acc_X": accx,"Acc_Y": accy,"Acc_Z": accz, "MagX": magx, "MagY": magy, "MagZ": magz})
        
        
if __name__ == "__main__":
    app.run(host="0.0.0.0", port=80)
        
        