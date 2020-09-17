from typing import Optional
from time import sleep

from fastapi import FastAPI
from fastapi.middleware.cors import CORSMiddleware

app = FastAPI()

origins = ['http://localhost:3000']

app.add_middleware(CORSMiddleware,
        allow_origins=origins,
        allow_credentials=True,
        allow_methods=["*"],
        allow_headers=["*"])

@app.get("/")
async def hello_world():
    sleep(2)
    return {"message": "Hello, world!"}

