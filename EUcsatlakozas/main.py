class EUorszagok:
    def __init__(self,sor):
        darabol = sor.strip().split(';')
        self.nev = darabol[0]
        self.belepes = darabol[1]

def beolvas():
    eu = []
    with open('EUcsatlakozas.txt') as fajl:
        next(fajl)
        for i in fajl:
            osztaly = EUorszagok(i) # egy EUorszagok objektum (példány)
            eu.append(osztaly)      # objektumokat tároló tömb
    return eu

def tagok2018(l):
    sz = 0
    for i in range(len(l)):
        datum = l[i].belepes.strip().split('.')
        if int(datum[0]) <= 2018:
            sz += 1
    return sz

def csatlakozott2007(l):
    sz = 0
    for i in range(len(l)):
        datum = l[i].belepes.strip().split('.')
        if int(datum[0]) == 2007:
            sz += 1
    return sz

def Magyarorszag(l):
    for i in range(len(l)):
        if l[i].nev == 'Magyarország':
            print('Magyarország csatlakozásának dátuma: ',l[i].belepes)

def majuscsat(l):
    sz = 0
    for i in range(len(l)):
        datum = l[i].belepes.strip().split('.')
        if datum[1] == '05':
            print('Történt csatlakozás májusban.')
            break

def utoljaracsat(l):
    for i in range(len(l)):
        datum = l[i].belepes.strip().split('.')
        # ez a maximumkiválasztás algoritmusa
        # a datum[0] közül kell a maximumot megtalálni

orszagok = beolvas()
# print(orszagok[0].belepes)

print('3. feladat')
szam = tagok2018(orszagok)
print('A 2018-ban lévő tagok száma: ',szam)

print('4. feladat')
szam2007 = csatlakozott2007(orszagok)
print('A 2007-ben csatlakozott országok száma: ',szam2007)

print('5. feladat')
Magyarorszag(orszagok)

print('6. feladat')
majuscsat(orszagok)

print('7. feladat')
utoljaracsat(orszagok)