using Domain.Common;

namespace Domain.Entities
{
    public class Soul: BaseEntity<Guid>
    {
        public required IReadOnlyList<Attribute> Attributes { get; set; }
    }
}

// Emissão: Eles tem a capecidade de arremeçar e projetar a aura. Normalmente quando a aura separada de seu corpo e que foi arremeçada diminui de intensidade em um curto período de tempo,
// mas conforme dominar a técnica o usuário poderá manter maiores intensidades por mais tempo.
// Os usuários da Emissão sao impacientes e não prestam a atenção nos detalhes. Por isso, normalmente são irritados e de “pavio curto”.

// Manipulação: Podem controlar objetos ou seres vivos. As habilidades de um manipulador são limitadas. Para poder aumentar o controle sobre aquilo que deseja, o manipulador terá de enfrentar certas condições.
// Os manipuladores são pessoas lógicas que gostam de avançar em seu próprio ritmo, para eles argumentos são tudo.
// - Solicitação ("tipo de solicitação") - Manipuladores deixam a livre vontade da vítima, mas garantem que ela esteja trabalhando a seu favor. Um exemplo de habilidade do tipo solicitação é manipular as memórias do alvo.
// - Coercitiva("tipo de compulsão") - Manipuladores exercem controle total sobre a vítima, assumindo tanto sua mente quanto seu corpo.
// - Pseudo-coercitiva ("tipo de meia compulsão") - Manipuladores ou assumem o corpo da vítima ou a prendem em uma situação em que não têm escolha a não ser seguir as ordens do Manipulador.
// As especificidades do tipo de indução difusiva - Foi descrito como fracamente coercitivo, mas capaz de influenciar um grande número de pessoas, o que se viu acontecer ao afetar suas emoções em relação a um objeto específico.

// Conjuração - Materialização: Materializar um objeto proveniente da aura. Quando o usuário dominar a invocação do objeto de seu desejo, ele pode fazê-lo aparecer e desaparecer e aparecer em um instante.
// Os materializadores são sensíveis e nervosos. Muitas vezes tão na defensiva. São bastante espertos e dificilmente são enganados.

// Transmutação - Transformação: Podem mudar as propriedades da aura. Os da transformação podem transformar as propriedades da sua aura para que ela imite a propriedades de alguma outra coisa
// (como a eletricidade), 1 exemplo é o Killua.
// Os transformadores são grandes mentirosos, muitos deles são imprevisíveis.

// Aprimoramento - Intensificação - Reforço : Eles fortalecem o poder de habilidades naturais, como a força física, resistência e habilidade de cura ou eles podem também fortalecer objetos.
// Entre os 6 tipos de Nen os da Intensificação são os mais balanceados.
// Eles são simples e determinados. Sua grande maioria não gosta de mentir, são sinceros e diretos naquilo que pensam.

// Especialização: Tipo único, imprevisível de aura. Especialização é a técnica que não se encaixa em nenhuma outra categoria. Pode ser literalmente qualquer tipo de habilidade, como o Crollo que rouba habilidades.
// Eles são carismáticos e independentes (egoistas), dirá algo importante sobre si mesmo mais tentara manter a distancia.