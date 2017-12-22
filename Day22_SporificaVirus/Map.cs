using System.Collections.Generic;

namespace Day22_SporificaVirus
{
    internal class Map
    {
        private Dictionary<(int row, int column), State> _nodes;

        public Map()
        {
            _nodes = new Dictionary<(int row, int column), State>();
        }

        public Point Position { get; set; }
        public Direction Direction { get; set; }
        public State Current =>
            _nodes.TryGetValue((Position.Row, Position.Column), out State state) ? state : State.Clean;

        internal void ChangeState(bool advancedStates)
        {
            if (!_nodes.TryGetValue((Position.Row, Position.Column), out State currentState))
            {
                currentState = State.Clean;
                _nodes.Add((Position.Row, Position.Column), currentState);
            }

            switch (currentState)
            {
                case State.Clean:
                    _nodes[(Position.Row, Position.Column)] = advancedStates ? State.Weakened : State.Infected;
                    break;
                case State.Weakened:
                    _nodes[(Position.Row, Position.Column)] = State.Infected;
                    break;
                case State.Infected:
                    _nodes[(Position.Row, Position.Column)] = advancedStates ? State.Flagged: State.Clean;
                    break;
                case State.Flagged:
                    _nodes[(Position.Row, Position.Column)] = State.Clean;
                    break;
            }
        }

        internal void SetState(Point position, State state)
        {
            _nodes.Add((position.Row, position.Column), state);
        }
    }
}