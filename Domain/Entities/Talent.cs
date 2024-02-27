using Domain.Common;

namespace Domain.Entities
{
    public class Talent: BaseEntity<Guid>
    {
        public required string Name { get; set; }
        public required virtual Requirement Requirement { get; set; }
        public required virtual IReadOnlyList<Metric> Metrics { get; set; }
    }
}

// Gyo é uma aplicação avançada de Ren, na qual um usuário de Nen concentra uma grande quantidade de aura em uma parte específica do corpo.
// Isso aumenta a força dessa parte do corpo, mas deixa o resto do corpo mais vulnerável, já que é um trade-off entre proteção menor e amplificação maior em um lugar específico.
// Geralmente é usado para melhorar a percepção do usuário e ver estruturas de Nen escondidas pelo uso de In.

// In é uma aplicação avançada de Zetsu que torna a aura do usuário imperceptível para usuários de Nen que podem ver o Nen invisível, mesmo a aura extremamente poderosa é oculta.
// Ele esconde dos cinco sentidos normais e até mesmo da percepção extra-sensorial de usuários de Nen. In pode ser visto através do Gyo.

// En é uma aplicação avançada de Ten e Ren, na qual o usuário estende a aura por uma certa distância usando Ren para estender sua aura Ten para dar forma a ela, normalmente uma esfera.
// Os requisitos mínimos para En são estender a aura por dois metros e mantê-la por um minuto. Qualquer coisa dentro de En é instantaneamente percebida pelo usuário.

// Shu é uma aplicação avançada de Ten, que envolve objetos em aura, permitindo que eles a usem como uma extensão do corpo do usuário.

// Ken é uma aplicação avançada de Ten e Ren. É principalmente uma técnica defensiva através do uso prolongado de Ren. Ken defende todo o corpo igualmente. Também pode ser usado como uma En em miniatura.

// Ko é uma combinação de Ten, Zetsu, Hatsu, Ren e Gyo para concentrar a aura do usuário em uma parte específica do corpo. Ten mantém a aura ao redor do local. Zetsu interrompe o fluxo de aura em todos os outros lugares.
// Ren aumenta exponencialmente a quantidade de aura no local. No entanto, a aura ao redor do corpo é dispersada, deixando o usuário vulnerável.

// Ryu é o uso de Gyo e Ken dentro de combate ativo, designando porcentagens de aura para diferentes partes do corpo quando necessário.

// Ten, Ren, Ko, Ken, Shu e Ryu todos melhoram as características físicas, com Ko concentrando toda a aura em um só lugar, Ken sendo um uso prolongado de Ren,
// Shu estendendo a aura em objetos físicos para melhorar fisicamente e Ryu dividindo a aura em diferentes lugares e proporções ao mesmo tempo.
// Também concede agilidade e mobilidade aprimoradas (pulando muito mais alto e mais longe, etc.)