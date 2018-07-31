import machine
import time
import socket
import bme280
import network

WLANSSID = 'VONETS_1C678C'
WLANPASSWORD = '12345678'
IPADRESS = '192.168.253.'
FIRSTNUMBER = 100
NEWIP = IPADRESS + str(FIRSTNUMBER)
ADD=0
RANGE = 100
PORT = 10000
Connected = False
BLUELED = machine.Pin(2, machine.Pin.OUT)
REDLED = machine.Pin(16, machine.Pin.OUT)
BLUELED.on()
sta_if = None

def ProblemWithConnect():
        time.sleep(0.5)
        BLUELED.off()
        time.sleep(0.5)
        BLUELED.on()

def ProblemWithBME():
    while True:
        time.sleep(0.5)
        BLUELED.off()
        time.sleep(0.5)
        BLUELED.on()
        
def BMEConnect():
        global BME
        try:
            i2c = machine.I2C(scl=machine.Pin(4), sda=machine.Pin(2))
            BME = bme280.BME280(i2c=i2c)
        except:
            ProblemWithBME()
        
def WifiConnect():
    global sta_if
    sta_if = network.WLAN(network.STA_IF)
    sta_if.active(True)
    sta_if.connect(WLANSSID, WLANPASSWORD)
    REDLED.off()
    while not sta_if.isconnected():
        pass
    REDLED.on()
        
def GetData():
    data = SOCKET.recv(1024)
    udata = data.decode('utf_8')
    return udata
    
def GetWithout():
    SOCKET.recv(1024)

def SendData(data):
    data = data.encode('utf_8')
    SOCKET.send(data)
    
def C0nnectToServer(IP=NEWIP):
    global SOCKET, Connected
    print(IP)
    SOCKET = socket.socket()
    SOCKET.settimeout(0.3)
    SOCKET.connect((IP, PORT))
    SOCKET.settimeout(5)
    print(GetData())
    SendData('VISUAL\r\n')
    if GetData()[:4] != '<OK>':
        ProblemWithConnect()
        print(1)
    SendData('LOGIN Sender pass\r\n')
    if GetData()[:4] != '<OK>':
        ProblemWithConnect()
        print(2)
    SendData('USE METEOR\r\n')
    if GetData()[:4] != '<OK>':
        ProblemWithConnect()
        print(3)
    Connected = True
        
        
    

def Working():
    try:
        while True: # 斜械褋泻芯薪械褔薪褘泄 褑懈泻谢
            data1, data2, data3 = BME.values # 蟹邪锌懈褋褜 写邪薪薪褘褏 胁 锌械褉械屑械薪薪褘械
            # data1 - 褌械屑锌械褉邪褌褍褉邪
            # data2 - 写邪胁谢械薪懈械
            # data3 - 胁谢邪卸薪芯褋褌褜
            BLUELED.on() # 胁褘泻谢褞褔械薪懈械 谐芯谢褍斜芯谐芯 褋胁械褌芯写懈芯写邪
            SendData('SET TEMPERATURE {}\r\n'.format(data1)) # 褍褋褌邪薪芯胁泻邪 锌械褉械屑械薪薪芯泄 TEMPERATURE 蟹薪邪褔械薪懈褟 data1
            GetWithout() # 锌芯谢褍褔懈褌褜 写邪薪薪褘械 芯褌 褋械褉胁械褉邪 懈 薪懈泻褍写邪 薪械 蟹邪锌懈褋褘胁邪褌褜
            SendData('SET PRESSURE {}\r\n'.format(data2)) # 褍褋褌邪薪芯胁泻邪 锌械褉械屑械薪薪芯泄 PRESSURE 蟹薪邪褔械薪懈褟 data2
            GetWithout() # 锌芯谢褍褔懈褌褜 写邪薪薪褘械 芯褌 褋械褉胁械褉邪 懈 薪懈泻褍写邪 薪械 蟹邪锌懈褋褘胁邪褌褜
            SendData('SET HUMIDITY {}\r\n'.format(data3)) # 褍褋褌邪薪芯胁泻邪 锌械褉械屑械薪薪芯泄 HUMIDITY 蟹薪邪褔械薪懈褟 data3
            GetWithout() # 锌芯谢褍褔懈褌褜 写邪薪薪褘械 芯褌 褋械褉胁械褉邪 懈 薪懈泻褍写邪 薪械 蟹邪锌懈褋褘胁邪褌褜
            BLUELED.off() # 胁泻谢褞褔械薪懈械 谐芯谢褍斜芯谐芯 褋胁械褌芯写懈芯写邪
    except Exception as ex:
        print(ex)
        ProblemWithConnect()
    
def main():
  global NEWIP, ADD, Connected
  while True:
      BMEConnect()
      try:
        WifiConnect()
        C0nnectToServer(NEWIP)
        Working()
      except Exception as ex:
        print(ex)
        if not Connected:
          ADD +=1
          if ADD > RANGE:
            ADD=0
          NEWIP = IPADRESS + str(ADD + FIRSTNUMBER)
          

main()







