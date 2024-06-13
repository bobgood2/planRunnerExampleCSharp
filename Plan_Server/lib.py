
# example on how to set up a library of additional functions that can be called from within
# executed code.  for example otherFunc() in global namespace will ending up returning 2.
#
# the setup method is called each time code is executed, so all fields stored in the class have the scope
# of the current execution, and can be shared across functions in the class, but will not be global to the
# original executed code.
#
# the reason the the orchestrator is provided is so that you can dynamically grow the workflow Dag
# with these functions if you want non-blocking calls  (don't use async here)
# see orchestrator.py

def __setup__(orchestrator):
    return {'_external_lib': Lib(orchestrator)}

def otherFunc():
    global _external_lib
    _external_lib.otherFunc()
    
class Lib:
    def __init__(self, orchestrator):
        self.orchestrator = orchestrator
        
    def otherFunc():
        return 2

