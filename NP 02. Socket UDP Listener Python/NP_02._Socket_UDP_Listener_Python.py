import socket
from threading import local

local_ip = '127.0.0.1'
local_port = 27001
buffer_size = 1024
msg = ''
UDP_client_socket = socket.socket(family=socket.AF_INET, type=socket.SOCK_DGRAM)

UDP_client_socket.bind((local_ip, local_port))

while True:
    bytes_address_pair = UDP_client_socket.recvfrom(buffer_size)
    msg = bytes_address_pair[0]
    print(msg.decode('utf-8'), end='')
