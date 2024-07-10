﻿CREATE TABLE [dbo].[Prodotti] (
    [IDProdotto]      INT             IDENTITY (1, 1) NOT NULL,
    [Nome]            NVARCHAR (255)  NOT NULL,
    [Descrizione]     NVARCHAR (255)  NULL,
    [Prezzo]          DECIMAL (10, 2) NOT NULL,
    [Categoria]       NVARCHAR (100)  NULL,
    [DataInserimento] DATETIME        DEFAULT (getdate()) NULL,
    [ImmagineLink]    NVARCHAR (255)  NULL,
    PRIMARY KEY CLUSTERED ([IDProdotto] ASC)
);





--popolamento tabella Prodotti
INSERT INTO [dbo].[Prodotti] 
([Nome],[Descrizione],[Prezzo],[Categoria],[DataInserimento],[ImmagineLink])
VALUES 
('T-Shirt DITO MEDIO',
'Una maglietta con un dito medio. Cosa già vista, sì, ma non ne ho trovata una che non fosse talmente kitsch da far rivoltare lo stomaco a qualsiasi designer. Questa volta me la tiro, perché questa è veramente bella. Lascia perdere le foto che non so farle, ma questo dito medio piccolo, messo su un lato del petto, è fatto veramente bene.',
10.50,
'T-Shirt',
GETDATE(),
'https://in-differente.it/wp-content/uploads/2024/05/WhatsApp-Image-2024-05-24-at-10.46.41-3.jpeg'
),
('Borraccia – Bevi, caz*o!',
'La borraccia bevi, caz*o! (censuro per i maledetti algoritmi) è ciò che più ti stimolerà a bere.La borraccia è unica, ha la scritta bevi, caz*o! stampata. Ammetto che è uno dei prodotti riusciti meglio di sempre. È una borraccia di alta qualità. È made in China come il 99% delle cose che compri.',
22.50,
'Borraccia',
GETDATE(),
'https://in-differente.it/wp-content/uploads/2023/04/IMG-4917-scaled-e1682602651790-600x600.jpg'
),
('Shopper Disagio',
'Il disagio è la parte integrante della nostra vita, ormai ci rappresenta e ne siamo consapevoli. Nel disagio troviamo l’agio, una comfort zone che ci spinge a insistere a fare sempre del nostro peggio. Il disagio è bello, non c’è niente di meglio che una sana dose di problemi da risolvere per risollevare la vita.',
7.50,
'Shopper',
GETDATE(),
'https://in-differente.it/wp-content/uploads/2023/11/disagioarancio.jpg'
),
('Poster – Fanculedì',
'È incredibile come le giornate di m*rda si susseguano una dopo l’altra, senza tregua, andando a riempire vite che altrimenti sarebbero talmente bianche da essere noiose.Il fanculedì è uno stile di vita, è qualsiasi giorno della settimana, è qualcosa che continua a ripetersi. Ce ne sono più di 52 ogni anno ed ognuno di essi è speciale a modo suo.',
9.90,
'Poster',
GETDATE(),
'https://in-differente.it/wp-content/uploads/2022/07/fanculedi%CC%80-scaled-e1651489537667-600x600.jpg'
),
('Poster - Tasse',
'Bestemmie a margine, E MO SO’ TASSE nasce dall’idea di una cliente schizzata come te, che ha saputo dar libero sfogo al mio pensiero quando il commercialista mi ha chiamato assicurandosi che fossi seduto. Perché le tasse fanno schifo, ma noi non glielo diciamo, sai mai che s’incarogniscano ancor di più.',
9.90,
'Poster',
GETDATE(),
'https://in-differente.it/wp-content/uploads/2024/05/WhatsApp-Image-2024-05-16-at-15.53.10-1024x1024.jpeg'
),
('Cappello trucker Che Palle',
'Sarà il completamento perfetto al tuo outfit sobrio ma piacente, perché una persona che indossa questo cappellino può essere solo così. Poi, per lamentarti, oltre al cappellino puoi anche corredare con maglietta e calzini. In questo modo hai il lamento a 360°.',
27.50,
'Cappelli',
GETDATE(),
'https://in-differente.it/wp-content/uploads/2024/06/WhatsApp-Image-2024-06-07-at-11.52.58-1-1024x1024.jpeg'
),
('Calzini BESTemmio',
'Per chi ha bisogno continuamente di ricongiungersi con l’altissimo, per tutti i veneti (ma non solo), per me che non manco di elogiarlo ogni minimo soffio di vento, per te, il tuo partner, i tuoi amici, i genitori, i figli, per chiunque abbia il bisogno viscerale di bestemmiare al prossimo.I calzini bestemmiano piano, al posto tuo, senza alcuna volgarità',
13.00,
'Calzini',
GETDATE(),
'https://in-differente.it/wp-content/uploads/2024/05/WhatsApp-Image-2024-05-27-at-17.58.38-1024x1024.jpeg'
),
('Calzini STIAMO CALMI',
'Gli STIAMO CALMI sono morbidi e comodi, sportivi, adatti ad essere indossati in qualsiasi occasione, sia per fare sport che per fare schifo. Indossarli ti darà un tocco di vita in più, regalarli ti potrà elevare a migliore amico di sempre per chi li riceverà.',
13.00,
'Calzini',
GETDATE(),
'https://in-differente.it/wp-content/uploads/2023/12/SCblu2-640x640.jpg'
),
('Calzini Lavorare Stanca',
'Andare a lavoro ogni giorno è un problema serio, farlo con i calzini giusti potrebbe alleviarne il peso, ma è evidente che non sarà così. Il lavoro resterà comunque una triste agonia alla quale ti sottoporrai quotidianamente. I calzini LAVORARE STANCA (vivere di più) si amalgamano alla perfezione ai jeans che indossi quando non hai voglia di vestirti per il verso, ovvero sempre. Si indossano facilmente anche con tutto il resto, in fondo sono universali.',
7.90,
'Calzini',
GETDATE(),
'https://in-differente.it/wp-content/uploads/2022/12/IMG-3515-scaled-e1672247315831.jpg'
),
('Calzini Ansia Disagio Stress',
'Con i calzini ansia & disagio & stress potrai sfoggiare con fierezza i tuoi tre principali problemi senza doverli giustificare. Sono calzini sportivi, morbidi e comodi, adatti ad ogni occasione. Da regalare a chi si lamenta in continuazione della propria vita.',
8.50,
'Calzini',
GETDATE(),
'https://in-differente.it/wp-content/uploads/2023/11/ansiadisastre1.jpg'
),
('Berretto caldo – ODIO TUTTI',
'Odiare la gente è ciò che ci contraddistingue. Ormai è difficile incontrare gente per strada e non avere il desiderio di mandarle a fare in culo nel minor tempo possibile. Odio tutti è il berretto caldo che ti ci vuole: è decisamente democratico e indossarlo durante le giornate fredde è necessario.',
15.50,
'Cappelli',
GETDATE(),
'https://in-differente.it/wp-content/uploads/2023/12/WhatsApp-Image-2024-02-08-at-14.17.15-2-1024x1024.jpeg'
),
('Borraccia – ACQUA SANTA',
'Una borraccia ironica e unica, troppo bella per essere vera. Ideale per distinguersi dalla massa di borracce banali. Il suo grip superiore permette un uso sicuro anche quando le fiamme dell’inferno ti faranno sudare le dita. La borraccia acqua santa, nonostante sia made in China, è così piena di santità che sembra quasi appropriato. Con il suo design blasfemo e originale, attirerà sicuramente l’attenzione ovunque tu vada.',
22.50,
'Borraccia',
GETDATE(),
'https://in-differente.it/wp-content/uploads/2024/03/WhatsApp-Image-2024-03-25-at-13.36.46-1-1024x1024.jpeg'
),
('T-Shirt RESILIENZA',
'Indossala per sfanculare tutti quelli che riempiono i social di post con scritto resilienza e come didascalia a foto che nemmeno su playboy. Dai va là, usiamo le parole difficili quando serve, non ad minchiam.',
12.90,
'T-Shirt',
GETDATE(),
'https://in-differente.it/wp-content/uploads/2022/07/resilienza-1-scaled-e1651832922438.jpg'
),
('T-Shirt BUONGIORNO',
'Campagna di sensibilizzazione contro la parola buongiorno. Non è un buongiorno, se non ti rispondo è perchè non ne sento il bisogno, se non ti saluto è perchè mi girano da prima di svegliarmi. Indossando la t-shirt Buongiorno Lo dici a qualcun altro nera puoi finalmente tacere come piace a te.',
14.90,
'T-Shirt',
GETDATE(),
'https://in-differente.it/wp-content/uploads/2022/07/buongiorno-scaled-e1651831137827.jpg'
),
('Shopper Mannaggia',
'La shopper Mannaggia è un’escalation di disagio. Usala per lo shopping, per i libri, per il disagio che porti con te ogni giorno. Comoda e pratica, resistente e bella. Ogni giorno puoi inveire verso il prossimo facendo parlare questa borsa al posto tuo.',
9.00,
'Shopper',
GETDATE(),
'https://in-differente.it/wp-content/uploads/2023/01/mannaggia.jpeg'
),
('Shopper Domani',
'È la shopper più intelligente che potessi tirar fuori, un connubio tra grafica figa, frase che il 95% della popolazione non può capire e un cotone che tiene su anche una cassa di acqua (piccola però). Se qualcuno dovesse chiederti il significato di quel che c’è scritto, l’unica giustificazione è che ha 60 anni e non ha studiato inglese. In caso contrario mandalo a vangare la terra, che l’ignoranza deve essere messa spalle al muro, anzi, faccia al muro.',
6.50,
'Shopper',
GETDATE(),
'https://in-differente.it/wp-content/uploads/2022/09/domanishopper.jpg'
),
('T-Shirt m’incazzo',
'Incazzarsi è una certezza quotidiana, sia con se stessi che con gli altri. È salutare e necessario, ma va fatto bene, con le giuste parole e imprecazioni. Quando tutto diventa insopportabile, serve qualcosa che tenga alla larga la gente: la maglietta m’incazzo. Questa maglietta trasmette chiaramente il messaggio di non rompere le palle. Ideale per chi vuole evitare rotture inutili e mantenere le distanze, specialmente se abbinata a un’ascella pezzata.',
12.90,
'T-shirt',
GETDATE(),
'https://in-differente.it/wp-content/uploads/2023/06/mincazzo2-scaled-e1688396057420-600x600.jpg'
);
