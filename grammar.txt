// http://lab.antlr.org/
grammar Antlr;

ifThenElseBlock: 'IF' if=booleanExpr 'THEN'
    then=thenBlock
    elseIf+=elseIfBlock*
    else=elseBlock?
    'END_IF'
    ;

thenBlock: actions+=assignExpr+;

elseBlock: 'ELSE' actions+=assignExpr+;

elseIfBlock: 'ELSE IF' predicate=booleanExpr 'THEN' actions+=assignExpr+ ;

assignExpr: var=VAR ':=' value=expr ';' ;

booleanExpr
    : left=booleanExpr op=OP_LOGIC right=booleanExpr    #predicateExpr
    | left=expr op=OP_LOGIC right=expr                  #logicExpr
    | left=expr op=OP_COMPARE right=expr                #compareExpr
    | name=VAR                                          #variableCheckExpr
    ;

expr
    : left=expr op=OP_MATH right=expr       #mathExpr
    | value=NUM                             #numberExpr
    | name=VAR                              #variableExpr
    ; 

OP_LOGIC
    : 'AND'
    | 'OR'
    ;

OP_COMPARE
    : '<'
    | '<='
    | '=='
    | '>'
    | '>='
    | '<>'
    ;

OP_MATH
    : '+'
    | '-'
    | '/'
    | '*'
    ;
    
NUM : [0-9]+ ;
VAR : ID ('.' ID)* ;
ID: [a-zA-Z_][a-zA-Z_0-9]*;
WS: [ \t\n\r\f]+ -> skip ;