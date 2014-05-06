from sympy import *
from sympy.logic.inference import *
import sys

CONVERSIONS = [ (' ^ ', ' & '), (' -> ', ' >> '), (' --> ', ' >> '), 
                (' v ', ' | '), (' <- ', ' << '), (' <-- ', ' << '), 
                (' ! ', ' ~ '), ('->', ' >> '), (' % ', ' <--> ') ]
                
                
KEYS = [ 'Identifier', 'Statement', 'Rule', 'Parent', 'Children' ]
SPLIT_LINE = '\n'
SPLIT_VALUE = ';'
SPLIT_LIST = ' '
ROOT_NAME = '1'
CLOSED_SYMBOL = 'x'
OPEN_SYMBOL = 'o'


def createTree(text):
    ''' 
    Creates a recursive dictionary to represent a truth tree using the 
    global variables KEYS, SPLIT_LINE,  SPLIT_VALUE, and SPLIT_LIST to 
    parse the text input
    '''
    Nodes = {}
    lines = text.strip(SPLIT_LINE).split(SPLIT_LINE)
    for line in lines:
        values = line.split(SPLIT_VALUE)
        node = dict(zip(KEYS, values))
        print(line)
        node['Children'] = node['Children'].strip().split(SPLIT_LIST)
        #node['Rule'] = node['Rule'].split(SPLIT_LIST)
        rule = node['Rule'].strip().split(SPLIT_LIST)
        print(rule)
        node['Rule'] = {'RuleName': rule[0], 'Variables': rule[1:]}
        Nodes[node['Identifier']] = node
    return Nodes

def createLogicStatement(string):
    '''
    Creates a logic statement from a given string using the global variable
    CONVERSIONS to convert to a sympy acceptable format.
    '''
    for old, new in CONVERSIONS:
        string = string.replace(old, new)
    return string.lower().strip()

def createConjunction(list_strings):
    '''
    Conjuncts a list of strings into a single string
    '''
    return '(' + ') & ('.join(list_strings) + ')'

def createDisjunction(list_strings):
    '''
    Disjuncts a list of strings into a single string
    '''
    return '(' + ') | ('.join(list_strings) + ')'

def checkDecomp(parent, children):
    '''
    Returns True if the parent statement is logically equivalent to the
    conjunction of the children statements. Raises an exception error if a 
    statement is not correctly formated
    '''
    try:
        parent = to_cnf(createLogicStatement(parent),simplify=True)
        children = to_cnf(createLogicStatement(createConjunction(children)),simplify=True)
        return Equivalent(parent, children) == True
    except:
        raise Exception("Could not understand statement")
        return False

def checkBranch(parent, children):
    '''
    Returns True if the parent statement is logically equivalent to the
    disjuntion of the children statements. Raises an exception error if a 
    statement is not correctly formated
    '''
    try:
        parent = to_cnf(createLogicStatement(parent),simplify=True)
        children = to_cnf(createLogicStatement(createDisjunction(children)), simplify=True)
        print(parent)
        print(children)
        return Equivalent(parent, children) == True
    except:
        raise Exception("Could not understand statement")
        return False

def checkContradiction(statements):
    '''
    Returns True if the conjuction of statements is a contradiction.
    '''
    try:
        conjunction = to_cnf(createConjunction(statements), simplify=True)
        return Equivalent(conjunction) == False 
    except:
        raise Exception("Could not understand statement")
        return False

def validateDecomp(Nodes, parent, children):
    '''
    Returns True if decomposition of parent node into children nodes
    was valid.
    ''' 
    parent_statement = Nodes[parent]["Statement"]
    children_statements = [Nodes[s]['Statement'] for s in children ]
    return checkDecomp(parent_statement, children_statements)

def validateBranch(Nodes, parent, children):
    '''
    Returns True if branch of parent statement into child staments is valid
    and all child statements in branch have same parent
    '''
    parent_statement = Nodes[parent]["Statement"]
    children_statements = [Nodes[s]['Statement'] for s in children ]
    valid_statement = checkBranch(parent_statement, children_statements)
    parents = [ Nodes[n]['Rule']['Variables'][0] for n in children ]
    #print(parents)
    parents = set(parents)
    return valid_statement and len(parents)==1

def validateClosed(Nodes, parents, child):
    '''
    Returns True if conjunction of parents is a contradiction and child statement
    is the contradiction symbol
    '''
    parent_statements = [Nodes[s]['Statement'] for s in parents ]
    valid_statement = checkContradiction(parent_statements)
    return (valid_statement) and (Nodes[child]['Statement'] == CLOSED_SYMBOL)

def validateOpen(Nodes, current, statements):
    ''' 
    Returns True if every statement is a literal or a negation of a literal
    '''
    ans = [ is_literal(s) for s in statements ]
    print(ans)
    #print(all(ans))
    return all(ans)

def validateTruthTree(Nodes, root=ROOT_NAME, statements=[]):
    '''
    Returns True if the truth tree is fully decomposed and every rule passed.
    Performs a DFS on Nodes starting at root, where statements is the set of
    unprocessed statements.
    '''
    rule = Nodes[root]['Rule']['RuleName']
    print(Nodes[root]['Rule'])
    if rule == 'Premise':
        new_statements = statements + list(Nodes[root]['Statement'])
        for child in Nodes[root]['Children']:
            ans = validateTruthTree(Nodes, root=child, statements=new_statements)
            if (ans == False):
                return False
        return True
    elif rule == 'Branch':
        new_statements = statements + list(Nodes[root]['Statement'])
        parent_rule_node = Nodes[root]['Rule']['Variables'][0]
        parent_node = Nodes[root]['Parent']
        new_statements = [x for x in new_statements if not (Nodes[parent_rule_node]['Statement'])]
        branch_nodes = Nodes[parent_node.strip()]['Children']
        if (validateBranch(Nodes, parent_rule_node, branch_nodes) == False):
            return False
        for child in Nodes[root]['Children']:
            ans = validateTruthTree(Nodes, root=child, statements=new_statements)
            if (ans == False):
                return False
        return True
    elif rule == 'Decomp':
        parent_rule_node = Nodes[root]['Rule']['Variables'][0]
        new_statements = [x for x in statements if not (Nodes[parent_rule_node]['Statement'])]
        decomp_rule = Nodes[root]['Rule']
        decomp_nodes = [root]
        new_statements = statements + list(Nodes[root]['Statement'])
        while (len(Nodes[root]['Children']) == 1) and \
                                        (Nodes[Nodes[root]['Children'][0]]['Rule'] == decomp_rule):
            root = Nodes[root]['Children'][0]
            decomp_nodes.append(root)
            new_statements += list(Nodes[root]['Statement'])
        print(decomp_nodes)
        if (validateDecomp(Nodes, parent_rule_node, decomp_nodes) == False):
            return False
        for child in Nodes[root]['Children']:
            ans = validateTruthTree(Nodes, root=child, statements=new_statements)
            if (ans == False):
                return False
        return True
    elif rule == 'Closed':
        parent_rule_nodes = Nodes[root]['Rule']['Variables']
        return validateClosed(Nodes, parent_rule_nodes, root) == False
    elif rule == 'Open':
        return validateOpen(Nodes, root, statements)
    else:
        raise Exception("Could not interpret rule")
        return False

def validateFromFile(text):
    '''
    Returns true if the truth tree associated with the text is valid
    '''
    Nodes = createTree(text)
    return validateTruthTree(Nodes)

if __name__ == "__main__":
    '''
    f = open('Tree1.txt')
    f = f.read()
    print(validateFromFile(f))
    f = open('Tree2.txt')
    f = f.read()
    print(validateFromFile(f))
    '''
    print(sys.argv)
    f = open(sys.argv[1])
    f = f.read()
    if not validateFromFile(f):
        print(False)
        sys.exit(1)
    print(True)



