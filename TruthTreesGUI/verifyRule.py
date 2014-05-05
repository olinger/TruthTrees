from verifyTree import *
import sys

if __name__ == "__main__":
    print(sys.argv)
    rule = sys.argv[-1]
    if rule == "D":
        parent = sys.argv[1]    
        children = sys.argv[2:-1]
        if not checkDecomp(parent, children):
            print(False)
            sys.exit(1)
        print(True)
    elif rule == "B":
        parent = sys.argv[1]    
        children = sys.argv[2:-1]
        print("Parent: ", parent)
        print("Childran: ", children)
        if not (checkBranch(parent, children)):
            print(False)
            sys.exit(1)
        print(True)
    elif rule == "Closed":
        parent = sys.argv[1]    
        children = sys.argv[2:-1]
        if not checkContradiction(parent, children):
            print(False)
            sys.exit(1)    
        print(True)
    elif rule == "Open":
        parent = sys.argv[1]    
        children = sys.argv[2:-1]
        if not checkOpen(children):
            print(False)
            sys.exit(1)
        print(True)
    else:
        sys.exit(1)

