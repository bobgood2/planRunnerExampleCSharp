
import ast_transform
from ast_transform import language_server
from ast_transform import common
import asyncio

async def main():
    config = common.Config()
    config.single_function=True  # changes the managed function calls, such that the function name is put in a parameter named: _fn

    server = language_server.ApiConductorServer(config)
    await server.start()
    
    await server.wait_for_close()
    
asyncio.run(main())
