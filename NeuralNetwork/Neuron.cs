using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NeuralNetwork
{
    public class Neuron
    {
        public List<double> Weights { get; }
        public NeuronType NeuronType { get; }
        public double Output { get; private set; }
        public List<Layer> Layers { get; }
        private double Sigmoid(double x)
        {
            return 1 / (1 + Math.Pow(Math.E, -x));
        }
        public Neuron(int inputsCount, NeuronType type = NeuronType.Hidden)
        {
            NeuronType = type;
            Weights = new List<double>();
            for (int i = 0; i < inputsCount; i++)
            {
                Weights.Add(1.0);
            }

        }
        public double FeedForward(List<double> inputSignals)
        {
            SendSignalsToInputNeurons(inputSignals);
        }
        private void SendSignalsToInputNeurons(List<double> inputSignals)
        {
            for (int i = 0; i < inputSignals.Count; i++)
            {
                List<double> signal = new List<double>() { inputSignals[i] };
                Neuron neuron = Layers[0].Neurons[i];
                neuron.FeedForward(signal);
            }
        }
        private void FeedForwardAllLayersAfterInput()
        {
            for (int i = 1; i < Layers.Count; i++)
            {
                Layer layer = Layers[i];
                List<double> previousLayerSignals = Layers[i - 1].GetLayerSignals();
            }
        }
        public override string ToString()
        {
            return Output.ToString();
        }
    }
}
