# LIGHTRACE 3D - Game Design Document

## Visão Geral
**LightRace 3D** é um jogo de ação arcade competitivo inspirado no conceito das Light Cycles de TRON, porém com mecânicas próprias, modos de jogo variados e uma arena dinâmica.

O jogador controla uma moto futurista que deixa um rastro sólido de energia. Colidir com qualquer obstáculo resulta em eliminação imediata.

O jogo deve proporcionar partidas rápidas, estratégicas e altamente competitivas.

## Gênero
- Arcade
- Ação
- Competitivo
- Multiplayer
- Estratégia em Tempo Real

## Plataforma
Inicialmente:
- Windows

Arquitetura preparada para:
- Linux
- macOS
- Android

## Engine
- Unity 6
- C#
- Universal Render Pipeline (URP)

## Estilo Visual
Visual futurista inspirado em Tron Legacy, Cyberpunk e Synthwave.
Características:
- iluminação emissiva
- bloom intenso
- partículas futuristas
- ambiente escuro
- piso reflexivo
- contraste elevado

## História
No ano de 2148, pilotos disputam torneios dentro de uma arena digital onde motos de energia criam barreiras de luz capazes de desintegrar qualquer veículo que as toque.

Cada partida é uma simulação em tempo real onde apenas um piloto pode sobreviver.

## Objetivo
Ser o último jogador vivo.

## Jogadores
- Mínimo: 2
- Máximo: 8

Suporte para:
- Multiplayer Online
- Multiplayer LAN
- Partida Local
- Contra IA

## Arena
Formato: quadrada
Tamanho: 150m × 150m

Características:
- piso metálico preto
- linhas luminosas
- paredes invisíveis
- iluminação neon
- reflexos

## Limites
Ao tocar parede ou borda: eliminação instantânea.

## Moto
Características:
- baixa
- futurista
- rodas fechadas
- iluminação neon
- efeitos de energia

## Cores disponíveis
- Azul
- Vermelho
- Verde
- Amarelo
- Roxo
- Laranja
- Branco
- Ciano

A cor do jogador aparece na moto, rastro, HUD, explosão e nome.

## Movimentação
- Movimento arcade
- Sem física realista
- Sem derrapagem
- Curvas instantâneas de 90°

### Controles
- W: acelerar
- S: frear
- A: virar esquerda
- D: virar direita
- Shift: turbo
- Espaço: freio de emergência
- ESC: menu

### Velocidades
- Velocidade padrão: 40 km/h
- Turbo: 55 km/h
- Freio: 25 km/h

## Sistema de Turbo
- Energia máxima: 100
- Consumo: 20/s
- Recuperação: 10/s
- HUD deve mostrar a barra

## Mecânica Principal — Rastro de Energia
Cada moto gera automaticamente um muro sólido de energia enquanto se movimenta.

Características:
- largura: 0,30 m
- altura: 2 m
- iluminação emissiva
- colisão ativa
- mesma cor da moto
- criado continuamente durante o movimento

Qualquer jogador que tocar o rastro ativo é eliminado instantaneamente.

## Sistema de Rastros
O jogo possui dois modos oficiais, cada um alterando completamente a estratégia da partida.

### Modo Clássico
- rastros permanentes
- nunca desaparecem
- arena vai ficando cada vez mais fechada
- estratégia baseada em cercar os adversários
- partidas mais tensas conforme o espaço diminui

### Modo Fluxo (Decay Mode)
- rastros possuem tempo de vida
- cada segmento permanece ativo por 10 segundos antes de desaparecer
- aviso visual 2 segundos antes de desaparecer
- brilho reduz gradualmente
- neon começa a piscar
- pequenas partículas digitais surgem
- transparência aumenta
- colisão é removida após o fim

### Modo Cobra
- limite máximo de comprimento do rastro
- segmentos antigos começam a desaparecer ao atingir o limite
- rastro funciona como cauda móvel
- exemplo: 120 segmentos de comprimento máximo

## Colisão
O jogador perde imediatamente ao tocar:
- qualquer rastro ativo
- qualquer parede
- borda da arena
- obstáculos futuros

## Explosão
Ao morrer:
- explosão neon
- partículas digitais
- efeito de desintegração
- fade da moto
- duração: 2 segundos

## IA
Quatro dificuldades:
- Fácil: pouca previsão, muitos erros, curvas simples
- Média: evita colisões, tenta sobreviver
- Difícil: cria armadilhas, fecha caminhos, usa turbo estrategicamente
- Insana: analisa arena, calcula espaço livre, direção dos adversários, melhores rotas e armadilhas

## HUD
Mostrar:
- velocidade
- energia
- jogadores vivos
- tempo da partida
- FPS
- ping
- mini mapa
- posição

## Mini Mapa
- vista superior
- mostra jogadores, rastros e arena
- atualização em tempo real

## Modos de Jogo
- Clássico: último sobrevivente, rastros permanentes
- Fluxo: último sobrevivente, rastros temporários
- Contra IA: seleciona quantidade e dificuldade
- Equipes: 2x2, 3x3, 4x4, última equipe viva vence
- Sobrevivência: IAs aparecem continuamente, objetivo sobreviver o máximo possível
- Corrida: sem rastros, apenas velocidade, circuitos futuristas

## Power-ups (Opcional)
- Turbo Infinito
- Escudo
- Invisibilidade do rastro
- Rastro duplo
- Rastro mais largo
- EMP
- Teleporte curto
- Congelamento do turbo inimigo

## Sons
- Motor
- Turbo
- Explosão
- Menu
- Cliques
- Vitória
- Derrota
- Power-ups

## Música
- Synthwave
- Cyberpunk
- Eletrônica
- Volume independente

## Interface
Menu Principal:
- Jogar
- Multiplayer
- Contra IA
- Personalizar
- Configurações
- Créditos
- Sair

## Estatísticas
Registrar:
- vitórias
- derrotas
- kills
- mortes
- tempo jogado
- maior sequência de vitórias
- maior sobrevivência
- uso de turbo
- distância percorrida
- curvas realizadas

## Arquitetura do Projeto
Scripts independentes:
- GameManager
- MatchManager
- PlayerController
- BikeController
- TrailManager
- TrailSegment
- TrailPool
- TrailRenderer
- CameraController
- InputManager
- NetworkManager
- LobbyManager
- SpawnManager
- AIController
- GameModeManager
- PowerUpManager
- AudioManager
- EffectsManager
- UIManager
- SettingsManager
- SaveManager
- StatisticsManager
- MiniMapManager

## Organização das Pastas
Veja a estrutura de pastas padrão no repositório.

## Multiplayer
- Netcode for GameObjects ou Mirror Networking
- arquitetura preparada para servidor dedicado
- criação de sala
- entrada por código
- matchmaking rápido
- lobby
- reconexão
- sincronização dos rastros e efeitos

## Otimização
- Object Pooling para segmentos de rastro
- GPU Instancing
- LOD
- Occlusion Culling
- URP Batcher
- Iluminação otimizada
- sincronização eficiente de rede
- meta 60 FPS estáveis em hardware intermediário
